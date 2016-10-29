using UnityEngine;
using System.Collections;

public class Thruster : AttachablePart
{
    public float thrustSpeed = 10f;

	public Vector3 thrustAxis;

    // Update is called once per frame
    public override void  ActivatePart()
    {
        selfRigidbody.AddRelativeForce(thrustAxis.normalized * thrustSpeed);
    }

    public override void DeactivatePart()
    {

    }

	void OnDrawGizmos()
	{
//		Gizmos.color = Color.magenta;
//		Gizmos.DrawRay (transform.position, -thrustAxis.normalized);
	}
}
