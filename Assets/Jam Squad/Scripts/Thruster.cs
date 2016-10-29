using UnityEngine;
using System.Collections;

public class Thruster : AttachablePart
{
    private float thrustSpeed= 50f;
    private KeyCode keyToActivate;

	// Use this for initialization
	public override void Initalize(KeyCode _keyToActivate)
    {
        keyToActivate = _keyToActivate;
		selfRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	public override void  ActivatePart ()
    {
		selfRigidbody.AddForce(transform.forward * thrustSpeed);
	}

	public override void DeactivatePart()
    {

    }
}
