﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DebrisFieldObstacle : Obstacle
{
    List<DebrisObstacle> debrisList;

    public GameObject debrisObstaclePrefab;

    public float spawnRadius;

    public Vector3 minScale;
    public Vector3 maxScale;

    // Use this for initialization
    public override void WasSpawned(Spawner spawner)
    {
        debrisList = new List<DebrisObstacle>();

        int randAmount = Random.Range(5, 20);
        for (int i = 0; i < randAmount; i++)
        {
            DebrisObstacle debris = (Instantiate<GameObject>(debrisObstaclePrefab).GetComponent<DebrisObstacle>());

            debris.transform.position = GetPointInSphere(spawnRadius, transform.position);
            debris.transform.SetParent(transform);

            Vector3 randomScale;
            float randomX = Random.Range(minScale.x, maxScale.x);
            float randomY = Random.Range(minScale.y, maxScale.y);
            float randomZ = Random.Range(minScale.z, maxScale.z);
            randomScale = new Vector3(randomX, randomY, randomZ);
            debris.transform.localScale = randomScale;

            debris.WasSpawned(spawner);

            debrisList.Add(debris);

            base.WasSpawned(spawner);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}