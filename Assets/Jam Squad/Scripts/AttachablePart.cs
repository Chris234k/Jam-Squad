using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class AttachablePart : MonoBehaviour{

	public static event Action<AttachablePart> OnJointBreak;

	[HideInInspector]
	public Rigidbody selfRigidbody;

	[HideInInspector]
	public Collider selfCollider;

	private FixedJoint fixedJoint;

	private AttachablePart connectedPart;

    const float COLLISION_BREAK_VELOCITY = 1f;

	void Start()
	{
		selfRigidbody 	= GetComponent<Rigidbody> ();
		selfCollider 	= GetComponent<Collider> ();

		selfRigidbody.useGravity = false;
		selfRigidbody.isKinematic = true;

		PlayerController.OnControlEnabled += HandleOnControlEnabled;
	}

	void HandleOnControlEnabled ()
	{
		selfRigidbody.isKinematic = false;
	}

	public void SetupJoint(AttachablePart argConnectedPart)
	{
		connectedPart 				= argConnectedPart;
		fixedJoint 					= this.gameObject.AddComponent<FixedJoint> ();
		fixedJoint.connectedBody 	= connectedPart.GetComponent<Rigidbody>();
		fixedJoint.enableCollision 	= false;
        PlayerController.instance.AttachPart(this);
		OnJointBreak += HandleOnJointBreak;
	}

	void HandleOnJointBreak (AttachablePart argBrokenPart)
	{
		if (argBrokenPart == connectedPart)
		{
			OnJointBreak -= HandleOnJointBreak;
			Destroy (fixedJoint);
		}
	}

    void OnCollisionEnter(Collision collision)
    {
        // Collides with ObstacleWall
        if(collision.gameObject.layer == 9)
        {
            Debug.Log("COLLISION VEL: " + collision.relativeVelocity.magnitude);
            //TODO Left off here, need to find appropriate factors to justify breakage
            if(collision.relativeVelocity.magnitude >= COLLISION_BREAK_VELOCITY)
            {
                OnJointBreak(this);
            }
        }
    }

	public virtual void Initialize(KeyCode keyToActivate)
	{

	}

	public virtual void ActivatePart()
	{

	}

	public virtual void DeactivatePart()
	{

	}
}
