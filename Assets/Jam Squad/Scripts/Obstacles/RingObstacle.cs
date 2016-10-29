using UnityEngine;
using System.Collections;

public class RingObstacle : Obstacle
{
    public override void WasSpawned(Spawner spawner)
    {

        base.WasSpawned(spawner);
    }

    public void OnCollisionEnter(Collision col)
    {
        // Speed boost player
    }
}