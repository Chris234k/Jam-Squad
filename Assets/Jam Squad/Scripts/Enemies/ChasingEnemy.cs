using UnityEngine;
using System.Collections;

public class ChasingEnemy : Enemy 
{
	[SerializeField]
	private float chasingSpeed = 5.0f;

	void FixedUpdate() 
	{
		if (!IsDead)
		{
			Vector3 direction = (this.player.transform.position - this.transform.position).normalized;
			this.rigidbody.velocity = direction * chasingSpeed;
		}
	}

	#region implemented abstract members of SpawnableBehavior

	public override void WasSpawned (Spawner spawner)
	{
		
	}

	#endregion

	void OnCollisionEnter(Collision collision) 
	{
		if (!IsDead)
		{
			GameObject.Destroy (this.gameObject, 5.0f);
			this.raiseDestroyed ();
			this.IsDead = true;
		}
	}
}
