using UnityEngine;
using System.Collections;

public class RingObstacle : Obstacle
{
    public override void WasSpawned(Spawner spawner)
    {
        float ySpinRate = Random.Range(-20, 20);
        float zSpinRate = Random.Range(-20, 20);

        spinRate = new Vector3(0, ySpinRate, zSpinRate);

        base.WasSpawned(spawner);
    }
}