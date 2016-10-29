using UnityEngine;
using System.Collections;

public class LazerWallObstacle : Obstacle
{
    public GameObject nodeA;
    public GameObject nodeB;

    public float spawnRadius;

    void Start()
    {
        WasSpawned(null);
    }

    public override void WasSpawned(Spawner spawner)
    {
        nodeA.transform.position = GetPointInSphere(spawnRadius, transform.position);
        nodeB.transform.position = GetPointInSphere(spawnRadius, transform.position);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}