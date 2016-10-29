using UnityEngine;
using System.Collections;

public class Thruster : AttachablePart
{
    public float thrustSpeed = 10f;

	public Vector3 thrustAxis;

	public ParticleSystem ps;

	ParticleSystem.EmissionModule em;

	private bool activated;

	void Start()
	{
		em = ps.emission;
		em.enabled = false;
	}

    // Update is called once per frame
    public override void  ActivatePart()
    {
		activated = true;
		ParticleSystem.EmissionModule em = ps.emission;
		em.enabled = true;
    }

    public override void DeactivatePart()
    {
		activated = false;
		ParticleSystem.EmissionModule em = ps.emission;
		em.enabled = false;
    }

	void OnDrawGizmos()
	{
//		Gizmos.color = Color.magenta;
//		Gizmos.DrawRay (transform.position, -thrustAxis.normalized);
	}

	void Update()
	{
		if (activated)
		{
			selfRigidbody.AddRelativeForce (thrustAxis.normalized * thrustSpeed);
		}
	}
}
