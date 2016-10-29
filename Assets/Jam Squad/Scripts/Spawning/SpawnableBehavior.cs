using UnityEngine;
using System.Collections;

public abstract class SpawnableBehavior : MonoBehaviour 
{
	public event System.Action<SpawnableBehavior> Destroyed;
	public virtual Vector3 Position 
	{
		set 
		{
			this.transform.position = value;
		}
	}

	protected virtual void raiseDestroyed()
	{
		if (this.Destroyed != null) 
		{
			this.Destroyed (this);
		}
	}
}
