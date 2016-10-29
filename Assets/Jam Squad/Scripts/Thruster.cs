using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class Thruster : MonoBehaviour,IAttachablePart
{
    private float thrustSpeed= 50f;
    private KeyCode keyToActivate;
    private Rigidbody selfRigidBody;

	// Use this for initialization
	public void Initalize(KeyCode _keyToActivate)
    {
        keyToActivate = _keyToActivate;
        selfRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	public void ActivatePart ()
    {
        selfRigidBody.AddForce(transform.forward * thrustSpeed);
	}
    public void DeactivatePart()
    {

    }
}
