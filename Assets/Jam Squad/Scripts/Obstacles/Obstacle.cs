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

    #region implemented abstract members of SpawnableBehavior

    public override void WasSpawned(Spawner spawner)
    {
        
    }

    #endregion

    protected void SpinUpdate()
    {
        transform.eulerAngles += spinRate * Time.deltaTime;
    }
}