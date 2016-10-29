using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Spawner : MonoBehaviour 
{
	[SerializeField]
	private Transform spawnPoint;

	[SerializeField]
	private float spawnRadius;

	[SerializeField]
	private List<SpawnableBehavior> spawnables;

	// Use this for initialization
	protected virtual void Start () 
	{
		if (this.spawnPoint == null) 
		{
			this.spawnPoint = this.transform;
		}
	}
		
	protected void spawn() 
	{
		if (spawnables.Count == 0) 
		{
			Debug.LogError ("No Spawnables in " + this.name);
		}

		int roll = Random.Range (0, spawnables.Count);
		GameObject obj = GameObject.Instantiate (spawnables [roll].gameObject);
		SpawnableBehavior spawnable = obj.GetComponent<SpawnableBehavior> ();

		willSpawn (spawnable);
		float distFromSpawnPoint = Random.Range (0, spawnRadius);
		float angle = Random.Range (0, 360);
		float x = Mathf.Cos (angle) * distFromSpawnPoint;
		float z = Mathf.Sin (angle) * distFromSpawnPoint;
		Vector3 position = new Vector3 (x, 0, z) + this.spawnPoint.position;
		spawnable.Position = position;
		spawnable.WasSpawned (this);
		didSpawn (spawnable);
	}

	protected abstract void willSpawn (SpawnableBehavior spawnable);
	protected abstract void didSpawn (SpawnableBehavior spawnable);
}
