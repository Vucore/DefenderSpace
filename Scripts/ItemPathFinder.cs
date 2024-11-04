using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPathFinder : MonoBehaviour
{
    
    ItemSpawner itemSpawner;
    WaveConfigSOItem waveConfigSOItem; 
    List<Transform> wayPoints;
    int wayPointIndex = 0;
    void Awake()
    {
        itemSpawner = FindAnyObjectByType<ItemSpawner>();
    }
    void Start()
    {
        waveConfigSOItem = itemSpawner.GetCurrentWave();
        transform.position = waveConfigSOItem.GetStartingItemWayPoint().position;
        wayPoints = waveConfigSOItem.GetWayItemPoints();
    }
    
    void Update()
    {
        FollowPath();
    }
    void FollowPath()
    {
        if(wayPointIndex < wayPoints.Count)
        {
            Vector3 targetPosition = wayPoints[wayPointIndex].position;
            float delta = waveConfigSOItem.GetMoveItemSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position == targetPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}
