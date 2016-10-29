using UnityEngine;
using System.Collections;

public class OnDestroySpawner : Spawner 
{
	protected override void Start() 
	{
		base.Start ();
		spawn ();
	}

	#region implemented abstract members of Spawner
	protected override void willSpawn (SpawnableBehavior spawnable)
	{
		
	}

	protected override void didSpawn (SpawnableBehavior spawnable)
	{
		spawnable.Destroyed += onSpawnableDestroyed;
	}
	#endregion

	private void onSpawnableDestroyed(SpawnableBehavior spawnable) {
		spawn ();
	}
}
