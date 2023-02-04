using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    //[SerializeField] Transform enemyPrefab;
    //[SerializeField] Transform spawnPoint;
    [SerializeField] float timeBetweenWaves = 5f;
    [SerializeField] float countdown = 2f;
    [SerializeField] TextMeshProUGUI waveCountdownText;

    [SerializeField] EnemySpawner enemySpawner = null;

    [SerializeField] private int waveIndex = 0;

    [SerializeField] EnemyType[] enemyTypes;
    [SerializeField] Transform[] spawnPoint;

    private void Update()
    {
        if (PauseMenu.isPause)
            return;
        if (countdown <= 0f)
        {
            waveIndex++;
            enemySpawner.SpawnWave(waveIndex);
            //StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Floor(countdown).ToString();
    }

    
    /*
    bool inUse = false;
    int currentWave = 0;
    [SerializeField] float SpawnRate = 1;
    float deltaTimeSpawn = 0;
    int enemiesSpawns = 0;

    public void SpawnWave(int index)
    {
        inUse = true;
        currentWave = index;
        deltaTimeSpawn = SpawnRate;
    }
    void Update()
    {
        if (PauseMenu.isPause)
            return;
        if (!inUse)
            return;
        if (deltaTimeSpawn < SpawnRate)
        {
            deltaTimeSpawn += Time.deltaTime;
        }
        else
        {
            deltaTimeSpawn = 0;
            SpawnEnemy();
            if (enemiesSpawns >= currentWave)
            {
                MyReset();
            }
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        enemiesSpawns++;
    }
    void MyReset()
    {
        inUse = false;
        enemiesSpawns = 0;
    }

    //IEnumerator SpawnWave()
    //{
    //    
    //    waveIndex++;
    //
    //    for (int i = 0; i < waveIndex; i++)
    //    {
    //        SpawnEnemy();
    //        yield return new WaitForSeconds(0.5f);
    //    }
    //}

    //void SpawnEnemy()
    //{
    //    Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    //}
    */
}
