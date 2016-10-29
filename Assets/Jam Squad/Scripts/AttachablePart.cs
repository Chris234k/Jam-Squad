using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class AttachablePart : MonoBehaviour
{

    public static event Action<AttachablePart> OnJointBreak;

    [SerializeField]
    protected bool unbreakable = false;

	public bool interactive = true;

    [HideInInspector]
    public Rigidbody selfRigidbody;

    [HideInInspector]
    public Collider selfCollider;

    protected FixedJoint fixedJoint;

    protected AttachablePart connectedPart;

    const float COLLISION_BREAK_VELOCITY = 1f;

    void Start()
    {
        
    }

	public virtual void Initialize(bool isCursor)
	{
		selfRigidbody = GetComponent<Rigidbody>();
		selfCollider = GetComponent<Collider>();

		selfRigidbody.useGravity = false;
		selfRigidbody.isKinematic = true;

		if (!isCursor)
		{
			PlayerController.OnControlEnabled += HandleOnControlEnabled;
		}
	}

	void Destroy()
	{
		PlayerController.OnControlEnabled -= HandleOnControlEnabled;
		AttachablePart.OnJointBreak -= HandleOnJointBreak;
	}

    void HandleOnControlEnabled()
    {
        selfRigidbody.isKinematic = false;
    }

    public void SetupJoint(AttachablePart argConnectedPart)
    {
        connectedPart = argConnectedPart;
        fixedJoint = this.gameObject.AddComponent<FixedJoint>();
        fixedJoint.connectedBody = connectedPart.GetComponent<Rigidbody>();
        fixedJoint.enableCollision = false;
        PlayerController.instance.AttachPart(this);
		AttachablePart.OnJointBreak += HandleOnJointBreak;
    }

    void HandleOnJointBreak(AttachablePart argBrokenPart)
    {
        if (argBrokenPart == connectedPart)
        {
			AttachablePart.OnJointBreak -= HandleOnJointBreak;
            Destroy(fixedJoint);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Collides with ObstacleWall or Enemy
        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 11)
        {
            //Debug.Log("COLLISION VEL: " + collision.relativeVelocity.magnitude);
            //TODO Need to find appropriate factors to justify breakage
            if (!unbreakable && collision.relativeVelocity.magnitude >= COLLISION_BREAK_VELOCITY)
            {
                FireJointBreak();
            }
        }
    }

    void FireJointBreak()
    {
		AttachablePart.OnJointBreak -= HandleOnJointBreak;
        Destroy(fixedJoint);

		if (AttachablePart.OnJointBreak != null)
        {
			AttachablePart.OnJointBreak(this);
        }
    }

    public virtual void ActivatePart()
    {

    }

    public virtual void DeactivatePart()
    {

    }

	public List<Renderer> GetRenderers()
	{
		List<Renderer> toReturn = new List<Renderer>();

		toReturn.AddRange(GetComponentsInChildren<Renderer> ());

		Renderer myRenderer = GetComponent<Renderer> ();

		if (myRenderer != null)
		{
			toReturn.Add (myRenderer); 
		}

		return toReturn;
	}

	public void SetCollidersEnabled(bool enabled)
	{
		Collider[] cols = GetComponents<Collider> ();

		for (int i = 0; i < cols.Length; i++)
		{
			cols [i].enabled = enabled;
		}

		cols = GetComponentsInChildren<Collider> ();

		for (int i = 0; i < cols.Length; i++)
		{
			cols [i].enabled = enabled;
		}
	}
}
