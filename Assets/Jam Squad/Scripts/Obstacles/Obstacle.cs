using UnityEngine;
using System.Collections;

public class Obstacle : SpawnableBehavior
{
    public Vector3 spinRate;
    bool shouldSpin;

    public override Vector3 Position
    {
        set
        {
            transform.position = value;
        }
    }

    #region implemented abstract members of SpawnableBehavior

    public override void WasSpawned(Spawner spawner)
    {
        if(spinRate.magnitude > 0)
        {
            shouldSpin = true;
        }
    }

    #endregion

    void Update()
    {
        if(shouldSpin)
        {
            SpinUpdate();
        }
    }

    protected void SpinUpdate()
    {
        transform.eulerAngles += spinRate * Time.deltaTime;
    }

    protected Vector3 GetPointInSphere(float radius, Vector3 center)
    {
        return Random.insideUnitSphere * radius + center;
    }
}