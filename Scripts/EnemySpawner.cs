using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigEnemy;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping = true;
    WaveConfigSO currentWave;
    
    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    IEnumerator SpawnEnemyWaves()
    {
        do 
        {   
            foreach (WaveConfigSO wave in waveConfigEnemy)
            {
                currentWave = wave;
                for(int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), 
                                currentWave.GetStartingEnemyWayPoint().position,
                                Quaternion.Euler(0, 0, 180),
                                transform);
                    yield return new WaitForSeconds(currentWave.GetRanDomSpawnEnemyTime());            
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }       
        }while(isLooping);   
    }
}
