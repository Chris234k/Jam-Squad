using UnityEngine;
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
