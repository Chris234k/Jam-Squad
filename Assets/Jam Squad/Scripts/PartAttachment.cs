using UnityEngine;
using System.Collections;

public class PartAttachment : MonoBehaviour {

	[SerializeField]
	private AttachablePart part;

	[SerializeField]
	private float rotationSpeed = 45.0f;

	private bool placingPart = false;
	private AttachablePart currentNewPart;
	private AttachablePart currentHitPart;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {

		if (placingPart)
		{
			if (PlayerController.instance.gameStarted)
			{
				Destroy (currentNewPart);
				currentNewPart = null;
				currentHitPart = null;
				placingPart = false;
			} 
			else
			{
				if (Input.GetKey (KeyCode.Q))
				{
					currentNewPart.transform.RotateAround (currentNewPart.transform.position, currentNewPart.transform.forward, -rotationSpeed * Time.deltaTime);
				} 
				else if (Input.GetKey (KeyCode.E))
				{
					currentNewPart.transform.RotateAround (currentNewPart.transform.position, currentNewPart.transform.forward, rotationSpeed * Time.deltaTime);
				}
			}
		}

		if (Input.GetMouseButtonDown (0) && !PlayerController.instance.gameStarted)
		{
			if (!placingPart)
			{
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (ray, out hit, 1000f))
				{
					Debug.DrawLine (transform.position, hit.point, Color.red, 3.0f);

					currentHitPart = hit.collider.transform.parent.GetComponent<AttachablePart> ();

					if (currentHitPart != null)
					{
						placingPart = true;

						currentNewPart 		= GameObject.Instantiate<AttachablePart> (part);
						currentNewPart.transform.position 	= hit.point;
						currentNewPart.transform.forward 	= hit.normal;
					}
				} 
				else
				{
					//Feedback if nothing hit?
				}
			} 
			else if (placingPart)
			{
				currentNewPart.SetupJoint (currentHitPart);

				currentNewPart 	= null;
				currentHitPart 	= null;
				placingPart 	= false;
			}
		}

	}
}
