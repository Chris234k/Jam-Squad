using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour 
{



	public float TurnSpeed;
	public float FireRate;
	private float fireRateTimer;
	private bool isActive;
	public float BulletSpeed;

	public Transform target;

	GameObjectPool bullets;
	public GameObject bullet;
	public GameObject bulletParent;

	public Material defaultMat;
	public Material activeMat;

	private Renderer self;

	GameObject load;
	BulletScript loadedBullet;

	void Start () 
	{
		self = GetComponent<Renderer> ();
		bullets = new GameObjectPool (15, bullet, bulletParent);
		fireRateTimer = FireRate;
	}

	void Update () 
	{
		if (isActive) 
		{
			fireRateTimer-= Time.deltaTime;
			if (fireRateTimer <= 0) 
			{
				load = bullets.GetNext();
				load.transform.position = gameObject.transform.position;
				loadedBullet = load.GetComponent<BulletScript>();
				loadedBullet.target = target.position;
				loadedBullet.movespeed = BulletSpeed;
				load.transform.LookAt(target);
				load.GetComponent<Rigidbody> ().AddRelativeForce(0,0,500);
				fireRateTimer = FireRate;
			}
		}
		else 
		{
				
		}
	
	}

	void OnTriggerEnter(Collider x)
	{
		if (x.CompareTag("Player")) 
		{
			isActive = true;
			self.material = activeMat;
			target = x.transform;
			Debug.Log("FOUND PLAYER");
		}
	}
	void OnTriggerExit(Collider x)
	{
		if (x.CompareTag("Player")) 
		{
			self.material = defaultMat;
			isActive = false;
		}

	}
}
