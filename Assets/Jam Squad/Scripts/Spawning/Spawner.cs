using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	[System.Serializable]
	private Transform spawnPoint;

	[System.Serializable]
	private float spawnInterval;

	[System.Serializable]
	private List<SpawnableBehavior> spawnables;

	// Use this for initialization
	void Start () {
	
	}

	IEnumerator spawnRoutine() {

	}
}
