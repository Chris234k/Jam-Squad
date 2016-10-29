using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PartSelectionUI : MonoBehaviour {

	public Text[] labels;

	public int currentIndex = -1;

	public void HighlightText(int index)
	{
		if (currentIndex >= 0 && currentIndex < labels.Length)
		{
			labels[currentIndex].color = Color.white;
		}

		currentIndex = index;

		if (currentIndex >= 0 && currentIndex < labels.Length)
		{
			labels[currentIndex].color = Color.red;
		}
	}
}
