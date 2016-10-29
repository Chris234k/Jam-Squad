using UnityEngine;
using System.Collections;

public class TurretScript : AttachablePart
{
    public float turnSpeed;

    public float fireRate;
    float lastFireTime;

    public float bulletSpeed;

    private bool isActive;

    Transform target;

    GameObjectPool bullets;
    public GameObject bullet;
    public GameObject bulletParent;

    public Material defaultMat;
    public Material activeMat;

    private Renderer self;

    GameObject load;
    BulletScript loadedBullet;

	public override void Initialize(bool isCursor)
	{
		base.Initialize (isCursor);

        if (!isCursor)
        {
            self = GetComponent<Renderer>();
            bullets = new GameObjectPool(15, bullet, bulletParent);
        }
	}

    void OnTriggerEnter(Collider col)
    {
        // If an enemy enters the turrets field of view
        if (col.gameObject.layer == 11)
        {
            isActive = true;
            self.material = activeMat;
            target = col.transform;
        }
    }

    void OnTriggerExit(Collider col)
    {
        // If an enemy leaves the turrets field of view
        if (col.gameObject.layer == 11)
        {
            self.material = defaultMat;
            isActive = false;
        }
    }

    public override void  ActivatePart()
    {
        // if target
        if (isActive)
        {
            // Check timer
            // fire at 1s
            // cd is 2s
            // needs to be at least 3s to fire again
            if (Time.time > lastFireTime + fireRate)
            {
                // Restart timer
                lastFireTime = Time.time;

                // Fire bullet
                load = bullets.GetNext();
                load.transform.position = gameObject.transform.position;
                loadedBullet = load.GetComponent<BulletScript>();
                loadedBullet.target = target.position;
                loadedBullet.movespeed = bulletSpeed;
                load.transform.LookAt(target);
                load.GetComponent<Rigidbody>().AddRelativeForce(0f, 0f, 2000f);

            }
        }
    }
}
