using UnityEngine;
using System.Collections;

public class Obstacle : SpawnableBehavior
{
    public Vector3 spinRate;

    public override Vector3 Position
    {
        set
        {
            throw new System.NotImplementedException();
        }
    }

    protected void SpinUpdate()
    {
        transform.eulerAngles += spinRate * Time.deltaTime;
    }
}