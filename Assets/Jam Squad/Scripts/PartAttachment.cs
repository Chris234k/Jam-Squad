using UnityEngine;
using System.Collections;

public class PartAttachment : MonoBehaviour {

	[SerializeField]
	private AttachablePart part;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, 1000f))
			{
				Debug.DrawLine (transform.position, hit.point, Color.red, 3.0f);

				AttachablePart hitPart = hit.collider.transform.parent.GetComponent<AttachablePart> ();

				if (hitPart != null)
				{
					AttachablePart newPart = GameObject.Instantiate<AttachablePart> (part);
					newPart.transform.position = hit.point;
					newPart.transform.forward = hit.normal;

					newPart.SetupJoint (hitPart);
				}
			} 
			else
			{
				//Feedback if nothing hit?
			}
		}
	}
}
