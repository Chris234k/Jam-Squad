using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour
{
	public static bool isBillboardingDisabled = false;

	[SerializeField]
	private bool isInversed = false;

	void Update ()
	{
		if (!isBillboardingDisabled) 
		{
			float inversion = 1.0f;
			if(!isInversed)
			{
				inversion = -1.0f;
			}

			transform.forward = inversion * (Camera.main.transform.position - transform.position);
		} 
		else 
		{
			float inversion = -1.0f;
			if(!isInversed)
			{
				inversion = 1.0f;
			}

			transform.forward = inversion * Vector3.forward;
		}


	}
}

