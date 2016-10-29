using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour 
{
	public Vector3 target = new Vector3(0,0,0);
	public float movespeed = 0f;
	public Vector3 startPos;
	public float timer =4f;
	// Use this for initialization
	void Start () 
	{
		//startPos = transform.position;
	}
	void OnEnable()
	{
		timer = 4f;
		//transform.position = startPos;

	}
	
	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;
		if (timer <= 0)
			gameObject.SetActive(false);

	}
}
