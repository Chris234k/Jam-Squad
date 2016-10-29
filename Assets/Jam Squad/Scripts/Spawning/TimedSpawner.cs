using UnityEngine;
using System.Collections;

public class TimedSpawner : Spawner 
{
	[SerializeField]
	private float spawnInterval;

	[SerializeField]
	private float startSpawningDelay;

	protected override void Start() 
	{
		base.Start ();
		StartCoroutine (spawnRoutine());
	}

	IEnumerator spawnRoutine() 
	{
		yield return new WaitForSeconds (startSpawningDelay);
		while (true)
		{
			spawn ();
			yield return new WaitForSeconds (spawnInterval);
		}
	}

	#region implemented abstract members of Spawner

	protected override void willSpawn (SpawnableBehavior spawnable)
	{
		
	}

	protected override void didSpawn (SpawnableBehavior spawnable)
	{
		
	}

	#endregion
}
