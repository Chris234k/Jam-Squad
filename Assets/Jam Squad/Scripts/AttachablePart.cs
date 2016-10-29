using UnityEngine;
using System;
using System.Collections;

public class AttachablePart : MonoBehaviour{

	public static event Action<AttachablePart> OnJointBreak;

	public Rigidbody rigidbody;

	private FixedJoint fixedJoint;

	private AttachablePart connectedPart;

	public void Initialize(AttachablePart argConnectedPart)
	{
		connectedPart 				= argConnectedPart;
		fixedJoint 					= this.gameObject.AddComponent<FixedJoint> ();
		fixedJoint.connectedBody 	= connectedPart.rigidbody;

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
	
	// Update is called once per frame
	//	void Update () {
	//		
	//	}
}
