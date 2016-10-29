﻿using UnityEngine;
using System.Collections;

public class DebrisObstacle : Obstacle
{
    // Use this for initialization
    void Start()
    {
        float ySpinRate = Random.Range(-20, 20);
        float zSpinRate = Random.Range(-20, 20);

        spinRate = new Vector3(0, ySpinRate, zSpinRate);
    }

    void Update()
    {
        SpinUpdate();
    }
}