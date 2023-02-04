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

    [SerializeField] EnemyType[] enemyTypes;
    [SerializeField] Transform[] spawnPoint;

    
    float deltaSpawn;
    float enemyCount;

    private void Update()
    {
        
        if (PauseMenu.isPause)
            return;
        if (countdown <= 0f)
        {
            countdown = timeBetweenWaves;
            
            foreach(EnemyType ET in enemyTypes)
            {
                ET.Amount = ET.MaxAmount;
                enemyCount += ET.Amount;

            }
            defaultDeltaSpawn = countdown * 0.9f/enemyCount;
            Debug.Log(enemyCount);
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
            Debug.Log(enemyTypes.Length);
            Debug.Log(enemyTypes[ID].Amount);
            Debug.Log(enemyCount);
            if (enemyTypes[ID].Amount > 0)
            {
                enemyTypes[ID].Amount -= 1;
                enemy = enemyTypes[ID].EnemyPrefab;
                
            }
        }

        Transform _spawnPoint = spawnPoint[Random.Range(0, spawnPoint.Length)];

        Instantiate(enemy, _spawnPoint.position, _spawnPoint.rotation);
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
