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

    private int waveIndex = 0; 

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
}
