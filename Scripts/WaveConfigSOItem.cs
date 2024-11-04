using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Wave Config Item", menuName = "New Wave Config Item")]
public class WaveConfigSOItem : ScriptableObject
{
    [Header("Item")]
    [SerializeField] List<GameObject> itemPrefabs;
    [SerializeField] Transform pathItemPrefabs;
    [SerializeField] float speedItemMove = 2f;
    [SerializeField] float timeBetweenItemSpawn = 10f;
    [Header("Sub Index")]
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;
    public Transform GetStartingItemWayPoint()
    {
        return pathItemPrefabs.GetChild(0);
    }
    public float GetMoveItemSpeed()
    {
        return speedItemMove;
    }
    public float GetRanDomSpawnItemTime()
    {
        float spawnTime = UnityEngine.Random.Range(timeBetweenItemSpawn - spawnTimeVariance,
                                        timeBetweenItemSpawn + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
    public int GetItemCount()
    {
        return itemPrefabs.Count;
    }
    public GameObject GetItemPrefabs(int index)
    {
        return itemPrefabs[index];
    }
      public List<Transform> GetWayItemPoints()
    {
        List<Transform> wayPoints = new List<Transform>();
        foreach (Transform child in pathItemPrefabs)
        {
            wayPoints.Add(child);
        }
        return wayPoints;
    }
}
