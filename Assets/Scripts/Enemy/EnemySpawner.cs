using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform enemyPrefab;
    [SerializeField] Transform spawnPoint;

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
        if (deltaTimeSpawn<SpawnRate)
        {
            deltaTimeSpawn += Time.deltaTime;
        }
        else
        {
            deltaTimeSpawn = 0;
            SpawnEnemy();
            if (enemiesSpawns>=currentWave)
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
}
