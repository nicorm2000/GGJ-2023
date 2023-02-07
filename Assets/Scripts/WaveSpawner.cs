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
    EnemyTipes[] enemyTypes;
    [SerializeField] Transform[] spawnPoint;

    float StartTime;
    float deltaSpawn;
    float enemyCount;
    float timestep;
    private void Start()
    {
        
        int n = 0;
        enemyTypes = new EnemyTipes[3];
        foreach (EnemyType ET in defaultEnemyTypes)
        {
            
            enemyTypes[n] = new EnemyTipes(ET.EnemyPrefab, ET.MaxAmount, ET.ScalingAmount, ET.DescalingAmount, ET.StartTime, ET.ScalingTime, ET.DescalingTime, ET.scalingTimer, ET.descalingTimer, ET.Amount, ET.Started);
            
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
            timestep = Time.realtimeSinceStartup - StartTime;
            foreach (EnemyTipes ET in enemyTypes)
            {
                

                if(timestep > ET.StartTime-1)
                {
                    if (ET.Started == false)
                    {
                        ET.scalingTimer = timestep + ET.ScalingTime;
                        ET.descalingTimer = timestep + ET.DescalingTime;
                        ET.Started = true;
                    }
                    else
                    {
                        if (timestep > ET.scalingTimer-1)
                        {
                            ET.MaxAmount += ET.ScalingAmount;
                            ET.scalingTimer += ET.ScalingTime;
                            Debug.Log("Scaling: " + ET.scalingTimer + " .. " + timestep);
                        }
                        if (timestep > ET.descalingTimer-1)
                        {
                            ET.MaxAmount -= ET.DescalingAmount;
                            ET.descalingTimer += ET.DescalingTime;
                        }
                    }
                    ET.Amount = ET.MaxAmount;
                    enemyCount += ET.Amount;
                    Debug.Log(ET.EnemyPrefab.name+" , "+ ET.Amount);
                }

                
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
            
            if (enemyTypes[ID].Amount > 0 && timestep > enemyTypes[ID].StartTime - 1)
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
