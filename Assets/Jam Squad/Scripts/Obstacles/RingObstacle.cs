using UnityEngine;
using System.Collections;

public class RingObstacle : Obstacle
{
    void Update()
    {
        SpinUpdate();
    }

    public void OnCollisionEnter(Collision col)
    {
        // Speed boost player
    }
}