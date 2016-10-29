using UnityEngine;
using System.Collections;

public class Thruster : AttachablePart
{
    private float thrustSpeed= 10f;
    private KeyCode keyToActivate;

	// Use this for initialization
	public override void Initialize(KeyCode _keyToActivate)
    {
        keyToActivate = _keyToActivate;
	}
	
	// Update is called once per frame
	public override void  ActivatePart ()
    {
		selfRigidbody.AddForce(-transform.forward * thrustSpeed);
	}

	public override void DeactivatePart()
    {

    }
}
