using UnityEngine;
using System.Collections;

public class ChargingEnemy : Enemy 
{
	[SerializeField]
	private float chargingSpeed = 5.0f;

	#region implemented abstract members of SpawnableBehavior

	public override void WasSpawned (Spawner spawner)
	{
		Vector3 direction = (this.player.transform.position - this.transform.position).normalized;
		this.rigidbody.velocity = direction * chargingSpeed;
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
