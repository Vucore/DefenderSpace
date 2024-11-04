using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfigSO;
    List<Transform> wayPoints;
    int wayPointIndex = 0;
    void Awake() 
    {
        enemySpawner = FindAnyObjectByType<EnemySpawner>();
    }
    void Start()
    {
        waveConfigSO = enemySpawner.GetCurrentWave();
        transform.position = waveConfigSO.GetStartingEnemyWayPoint().position;
        wayPoints = waveConfigSO.GetWayEnemyPoints();
        //transform.position = wayPoints[wayPointIndex].position;
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
            float delta = waveConfigSO.GetMoveEnemySpeed() * Time.deltaTime;
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
