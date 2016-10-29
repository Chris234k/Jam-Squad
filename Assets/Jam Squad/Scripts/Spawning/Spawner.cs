using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	[SerializeField]
	private Transform spawnPoint;

	[SerializeField]
	private float spawnInterval;

	[SerializeField]
	private List<SpawnableBehavior> spawnables;

	// Use this for initialization
	void Start () {
	
	}

	IEnumerator spawnRoutine() {

		return null;
	}
}
