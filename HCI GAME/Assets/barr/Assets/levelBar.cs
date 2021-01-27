using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelBar : MonoBehaviour
{

	public Slider slider;	
	public Image fill;

	public void SetMinLevel(int level)
	{
		slider.minValue = level;
		slider.value = level;

	}

    public void SetLevel(int level)
	{
		slider.value = level;
	}

}
