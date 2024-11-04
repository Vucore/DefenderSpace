using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.WSA;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSOItem> waveConfigItem;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping = false;
    WaveConfigSOItem currentWave;
    ScoreKeeper scoreKeeper;
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    public WaveConfigSOItem GetCurrentWave()
    {
        return currentWave;
    }
    void Start()
    {
        //StartCoroutine(TimeSpawn());
    }
    void Update()
    {
        StartCoroutine(TimeSpawn());
    }
    IEnumerator TimeSpawn()
    {
        //tt:
        yield return new WaitUntil(() => scoreKeeper.GetScore()  %100 == 50);
        StartCoroutine(SpawnItemWaves());
       // goto tt;
    }
    IEnumerator SpawnItemWaves()
    {
        //do
       // {
            foreach(WaveConfigSOItem wave in waveConfigItem)
            {
                currentWave = wave;
                for(int i = 0; i < currentWave.GetItemCount(); i++)
                {
                    Instantiate(currentWave.GetItemPrefabs(i),
                                currentWave.GetStartingItemWayPoint().position,
                                quaternion.identity);
                    yield return new WaitForSeconds(currentWave.GetRanDomSpawnItemTime());
                }
            }
            yield return new WaitForSeconds(timeBetweenWaves);//////
      //  }
       // while(isLooping);
    }
    
}
