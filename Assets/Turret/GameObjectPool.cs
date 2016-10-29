using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameObjectPool
{
	// List created based on the prefab passed in
	private GameObject[] list;

	// Index of the current GameObject in the list
	private int index = 0;

	// Object we want to create copies of, set through the constructor
	private GameObject prefab;

	// Setup the pool
	// Where numDuplicates is the amount of prefabs you want to create of _prefab
	// parent is optional, the pool will create one for you if it is not passed in
	public GameObjectPool (int numDuplicates, GameObject _prefab, GameObject parent = null, Transform spawnPosAndRot = null)
	{
		// Initialize array
		list = new GameObject[numDuplicates];

		// Spawn position and rotation
		// Applied upon instantiation
		Vector3 spawnPos;
		Quaternion spawnRot;

		// If we don't have a transform, use defaults
		if (spawnPosAndRot == null) {
			spawnPos = Vector3.zero;
			spawnRot = Quaternion.identity;
		} else { // store data if we have a Transform
			spawnPos = spawnPosAndRot.position;
			spawnRot = spawnPosAndRot.rotation;
		}

		// Loop through and setup the array with clones of the prefab
		for (int i = 0; i < numDuplicates; i++) {
			// If there is no parent object passed in
			// We create one
			if (parent == null) {
				// Parameters for GameObject constructor set it's name
				parent = new GameObject ("Game Object Pool: " + _prefab.name + " Parent");
			}

			// Create instance of the prefab
			GameObject go = (GameObject)MonoBehaviour.Instantiate (_prefab, spawnPos, spawnRot);

			// Add a number for identification purposes in inspector
			go.name += i;

			// Set parent as the one passed in (or the one we created)
			go.transform.SetParent (parent.transform, true);
			// Store created object in the list
			list [i] = go;

			// Hide GameObject until first use
			go.SetActive (false);
		}
	}

	// Returns the current GameObject
	// Current is updated by GetNext()
	public GameObject GetCurrent ()
	{
		GameObject current = list [index];
		if (!current.activeSelf) {
			current.SetActive (true);
		}

		return current;
	}

	// Updates the current object and returns it
	public GameObject GetNext ()
	{
		// Prevent us from trying to return something from an empty list
		if (list.Length > 0) {
			// Increment index if possible
			if (index + 1 < list.Length)
				index++;
			else // Index gets reset if it goes to the end of the list
				index = 0;

			// Now that the index is updated, GetCurrent will return the "next"
			return GetCurrent ();
		}
		//Debug.Log("NULL!");
		return null;
	}

	public void SetInactive (GameObject myGameObject)
	{

		for (int i = 0; i < list.Length; i++) {
			if (myGameObject == list [i]) {
				myGameObject.SetActive (false);
			}
		}
	}


}