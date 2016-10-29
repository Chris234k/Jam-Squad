using UnityEngine;
using System.Collections;

public class TestSpawnable : SpawnableBehavior {

	void Start() {
		Invoke ("Destroy", 2.0f);
	}

	void Destroy() {
		this.raiseDestroyed ();
		GameObject.Destroy (this.gameObject);
	}

	#region implemented abstract members of SpawnableBehavior

	public override void WasSpawned (Spawner spawner)
	{
		
	}

	#endregion
}
