using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
  
    [SerializeField] float timeBetweenWaves = 5f;
    [SerializeField] float countdown = 2f;
    [SerializeField] TextMeshProUGUI waveCountdownText;

    [SerializeField] float defaultDeltaSpawn;

    [SerializeField] EnemyType[] defaultEnemyTypes;
    [SerializeField] EnemyTipes[] enemyTypes;
    [SerializeField] Transform[] spawnPoint;

    float StartTime;
    float deltaSpawn;
    float enemyCount;

    private void Start()
    {
        
        int n = 0;
        enemyTypes = new EnemyTipes[3];
        foreach (EnemyType ET in defaultEnemyTypes)
        {
            Debug.Log("setup");
            enemyTypes[n] = new EnemyTipes(ET.EnemyPrefab, ET.MaxAmount, ET.ScalingAmount, ET.DescalingAmount, ET.StartTime, ET.ScalingTime, ET.DescalingTime, ET.scalingTimer, ET.descalingTimer, ET.Amount, ET.Started);
            Debug.Log(defaultEnemyTypes[n].EnemyPrefab.name);
               n += 1;
        }
        StartTime = Time.realtimeSinceStartup;
        foreach (EnemyTipes ET in enemyTypes)
        {
            
            ET.StartTime += StartTime;
        }
        
       
    }

    private void Update()
    {
        
        if (PauseMenu.isPause)
            return;
        if (countdown <= 0f)
        {
            countdown = timeBetweenWaves;
            enemyCount = 0;

            foreach (EnemyTipes ET in enemyTypes)
            {
                float _tiempoPasado = Time.realtimeSinceStartup - StartTime;

                if(_tiempoPasado > ET.StartTime)
                {
                    if(ET.Started == true)
                    {
                        ET.scalingTimer = _tiempoPasado + ET.ScalingTime;
                        ET.descalingTimer = _tiempoPasado + ET.DescalingTime;
                        ET.Started = false;
                    }
                    if (_tiempoPasado > ET.scalingTimer)
                    {
                        ET.MaxAmount += ET.ScalingAmount;
                        ET.scalingTimer += ET.ScalingTime;
                    }
                    if (_tiempoPasado > ET.descalingTimer)
                    {
                        ET.MaxAmount -= ET.DescalingAmount;
                        ET.descalingTimer += ET.DescalingTime;
                    }
                    ET.Amount = ET.MaxAmount;
                    enemyCount += ET.Amount;
                }

                Debug.Log(ET.EnemyPrefab.name +", "+ ET.Amount);
                Debug.Log(enemyCount);
            }
            defaultDeltaSpawn = countdown * 0.9f/enemyCount;
            
        }

        if (enemyCount > 0)
        {
            if (deltaSpawn > 0)
            {
                deltaSpawn -= Time.deltaTime;
            }
            else
            {

                deltaSpawn = defaultDeltaSpawn + Random.Range(-defaultDeltaSpawn, defaultDeltaSpawn / 2);
                //enemyTypes = enemyDefaultTypes;
                SpawnEnemy();

            }
        }

        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Floor(countdown).ToString();
    }

    

    public void SpawnEnemy()
    {
        Transform enemy = null;
        while (enemy == null)
        {
            int ID = Random.Range(0, enemyTypes.Length);
            
            if (enemyTypes[ID].Amount > 0 )
            {
                enemyTypes[ID].Amount -= 1;
                enemy = enemyTypes[ID].EnemyPrefab;
                
            }
        }

        Transform _spawnPoint = spawnPoint[Random.Range(0, spawnPoint.Length)];

        Vector3 _SpawnPosition = _spawnPoint.position + new Vector3(Random.Range(-1,1), Random.Range(0, 1), Random.Range(-1, 1));

        Instantiate(enemy, _SpawnPosition, _spawnPoint.rotation);
        enemyCount -= 1;


    }

    
    /*

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemiesSpawns++;
    }
  

 
    */
}
