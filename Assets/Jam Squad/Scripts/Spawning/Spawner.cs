using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	[SerializeField]
	private Transform spawnPoint;

	[SerializeField]
	private float spawnRadius;

	[SerializeField]
	private float spawnInterval;

	[SerializeField]
	private List<SpawnableBehavior> spawnables;

	// Use this for initialization
	void Start () {
		if (this.spawnPoint == null) {
			this.spawnPoint = this.transform;
		}
		spawn ();
	}

	IEnumerator spawnRoutine() {

		return null;
	}

	protected void spawn() {
		if (spawnables.Count == 0) {
			Debug.LogError ("No Spawnables in " + this.name);
		}

		int roll = Random.Range (0, spawnables.Count);
		GameObject obj = GameObject.Instantiate (spawnables [roll].gameObject);
		SpawnableBehavior spawnable = obj.GetComponent<SpawnableBehavior> ();
		float distFromSpawnPoint = Random.Range (0, spawnRadius);
		float angle = Random.Range (0, 360);
		float x = Mathf.Cos (angle) * distFromSpawnPoint;
		float z = Mathf.Sin (angle) * distFromSpawnPoint;
		Vector3 position = new Vector3 (x, spawnPoint.transform.position.y, z);
		spawnable.Position = position;
		spawnable.Destroyed += onSpawnableDestroyed;
	}

	private void onSpawnableDestroyed(SpawnableBehavior spawnable) {
		spawn ();
	}
}
