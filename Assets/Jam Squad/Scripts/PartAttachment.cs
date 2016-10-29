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
			if (Physics.Raycast (transform.position, transform.forward, out hit,1000f))
			{
				AttachablePart newPart 		= GameObject.Instantiate<AttachablePart> (part);
				newPart.transform.position 	= hit.point;
				newPart.transform.forward 	= hit.normal;


			}
		}
	}
}
