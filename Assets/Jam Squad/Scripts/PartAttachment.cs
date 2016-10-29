using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PartAttachment : MonoBehaviour {

	[SerializeField]
	private float rotationSpeed = 45.0f;

	[SerializeField]
	private LayerMask layerMask;

	[SerializeField]
	private PartSelectionUI partSelectionUI;

	private bool placingPart = false;
	private AttachablePart currentHitPart;

	[SerializeField]
	private Material cursorMaterial;

	[SerializeField]
	private AttachablePart[] partPrefabs;

	private AttachablePart cursor; //A holographic version of the part while we're placing it.

	private int currentPartIndex = -1;

	// Use this for initialization
	void Start () {
		SwitchPart (0);
		partSelectionUI.HighlightText (0);
	}

	// Update is called once per frame
	void Update () {

		CheckInput ();

		if (placingPart)
		{
			if (PlayerController.instance.gameStarted)
			{
				Destroy (cursor.gameObject);
				cursor = null;
				currentHitPart = null;
				placingPart = false;
			} 
			else
			{
				if (Input.GetKey (KeyCode.Q))
				{
					cursor.transform.RotateAround (cursor.transform.position, cursor.transform.forward, -rotationSpeed * Time.deltaTime);
				} 
				else if (Input.GetKey (KeyCode.E))
				{
					cursor.transform.RotateAround (cursor.transform.position, cursor.transform.forward, rotationSpeed * Time.deltaTime);
				}
			}
		}

		if (!PlayerController.instance.gameStarted)
		{
			if (!placingPart)
			{
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (ray, out hit, 1000f, layerMask.value, QueryTriggerInteraction.Ignore))
				{
					Debug.DrawLine (transform.position, hit.point, Color.red, 3.0f);

					currentHitPart = hit.collider.GetComponent<AttachablePart> ();
					if (currentHitPart == null)
					{
						currentHitPart = hit.collider.transform.parent.GetComponent<AttachablePart> ();
					}

					if (currentHitPart != null)
					{
						cursor.gameObject.SetActive (true);
						cursor.transform.position 	= hit.point;
						cursor.transform.forward 	= hit.normal;

						if (Input.GetMouseButtonDown (0))
						{
							placingPart = true;
						}
					}
				} 
				else
				{
					cursor.gameObject.SetActive (false);
				}
			} 
			else if (placingPart)
			{
				if (Input.GetMouseButtonDown (0))
				{
					AttachablePart newPart = GameObject.Instantiate<AttachablePart> (partPrefabs[currentPartIndex]);
					newPart.transform.position = cursor.transform.position;
					newPart.transform.rotation = cursor.transform.rotation;

					newPart.Initialize (false);

					newPart.SetupJoint (currentHitPart);

					currentHitPart 	= null;
					placingPart 	= false;
				}
			}
		}

	}

	//HACK: I know there's probably a better way to do this but I'm already wasting too much time haha.
	void CheckInput()
	{
		if (Input.GetKeyDown (KeyCode.Alpha0))
		{
			SwitchPart (9);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha1))
		{
			SwitchPart (0);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha2))
		{
			SwitchPart (1);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha3))
		{
			SwitchPart (2);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha4))
		{
			SwitchPart (3);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha5))
		{
			SwitchPart (4);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha6))
		{
			SwitchPart (5);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha7))
		{
			SwitchPart (6);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha8))
		{
			SwitchPart (7);
		}
		else if (Input.GetKeyDown (KeyCode.Alpha9))
		{
			SwitchPart (8);
		}
	}

	void SwitchPart(int partIndex)
	{
		if (currentPartIndex == partIndex || partIndex >= partPrefabs.Length)
		{
			return;
		}

		if (cursor != null)
		{
			Destroy (cursor.gameObject);
		}

		if (placingPart)
		{
			currentHitPart = null;
			placingPart = false;
		}

		currentPartIndex = partIndex;

		cursor = GameObject.Instantiate<AttachablePart> (partPrefabs [currentPartIndex]);

		cursor.Initialize (true);

		List<Renderer> renderers = cursor.GetRenderers ();

		for (int i = 0; i < renderers.Count; i++)
		{
			renderers [i].material = cursorMaterial;
		}

		cursor.SetCollidersEnabled (false);

		partSelectionUI.HighlightText (currentPartIndex);
	}
}
