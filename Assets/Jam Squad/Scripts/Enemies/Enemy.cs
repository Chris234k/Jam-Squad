using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public abstract class Enemy : SpawnableBehavior 
{
	public bool IsDead { get; protected set; }

	protected PlayerController player { get; private set; }
	protected Rigidbody rigidbody { get; private set; }

	protected void Awake() 
	{
		this.player = PlayerController.instance;
		this.rigidbody = GetComponent<Rigidbody> ();
	}
}
