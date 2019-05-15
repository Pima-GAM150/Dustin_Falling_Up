using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
	#region Variables

	[Tooltip("The ui slider obj that is going to show the amount of heath you have")]
	public Slider Bar;

	[Tooltip("The Color the bar will be when you are at a 1/4 or less of your Max health")]
	public Color BAD;

	private float prevHealth;
	
	#endregion
	
	#region Unity Functions
		
	private void Start()
	{
		prevHealth = PlayerController.Instance.Health;
		Bar.maxValue = prevHealth;
		Bar.value = Bar.maxValue;
	}
	    
	private void Update()
	{
        if(prevHealth!= PlayerController.Instance.Health)
		{
			prevHealth = PlayerController.Instance.Health;

			Bar.value = prevHealth;
		}

		if(Bar.value/Bar.maxValue <=.25f)
		{
			Bar.fillRect.GetComponent<Image>().color = BAD;
		}
	}
	
	#endregion
	
	#region My Functions
	
	
	
	#endregion
}