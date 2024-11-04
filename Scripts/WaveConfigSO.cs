using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
[CreateAssetMenu(fileName = "Wave Config", menuName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [Header("Enemy")]
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathEnemyPrefabs;
    [SerializeField] float speedEnemyMove = 5f;
    [SerializeField] float timeBetweenEnemySpawn = 1f;
    // [Header("Item")]
    // [SerializeField] List<GameObject> itemPrefabs;
    // [SerializeField] Transform pathItemPrefabs;
    // [SerializeField] float speedItemMove = 2f;
    // [SerializeField] float timeBetweenItemSpawn = 10f;
    [Header("Sub Index")]
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;
    public Transform GetStartingEnemyWayPoint()
    {
        return pathEnemyPrefabs.GetChild(0);
    }
    public List<Transform> GetWayEnemyPoints()
    {
        List<Transform> wayPoints = new List<Transform>();
        foreach (Transform child in pathEnemyPrefabs)
        {
            wayPoints.Add(child);
        }
        return wayPoints;
    }
    public float GetMoveEnemySpeed()
    {
        return speedEnemyMove;
    }
    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }
    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }
    public float GetRanDomSpawnEnemyTime()
    {
        float spawnTime = UnityEngine.Random.Range(timeBetweenEnemySpawn - spawnTimeVariance,
                                        timeBetweenEnemySpawn + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }




    // public Transform GetStartingItemWayPoint()
    // {
    //     return pathItemPrefabs.GetChild(0);
    // }
    // public float GetMoveItemSpeed()
    // {
    //     return speedItemMove;
    // }
    // public float GetRanDomSpawnItemTime()
    // {
    //     float spawnTime = UnityEngine.Random.Range(timeBetweenItemSpawn - spawnTimeVariance,
    //                                     timeBetweenItemSpawn + spawnTimeVariance);
    //     return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    // }
    // public int GetItemCount()
    // {
    //     return itemPrefabs.Count;
    // }
    // public GameObject GetItemPrefabs(int index)
    // {
    //     return itemPrefabs[index];
    // }
    //   public List<Transform> GetWayItemPoints()
    // {
    //     List<Transform> wayPoints = new List<Transform>();
    //     foreach (Transform child in pathItemPrefabs)
    //     {
    //         wayPoints.Add(child);
    //     }
    //     return wayPoints;
    // }
}
