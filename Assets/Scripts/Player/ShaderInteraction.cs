using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderInteraction : MonoBehaviour
{
	#region Variables

	public bool Edged;

	public Color Edge, Normal;

	public Material PlayerMat;
	
	#endregion
	
	#region Unity Functions
	
	private void Awake()
	{
		
	}
	
	private void Start()
	{
       
	}

    
	private void Update()
	{
		if (transform.position.x >= 8.5f || transform.position.x <= -8.5f) 
		{
			Edged = true;
		}
		else if (transform.position.y >= 8.5f || transform.position.y <= -8.5f)
		{
			Edged = true;
		}
		else
		{
			Edged = false;
		}
			

		ChangePlayerColor(Edged);
	}

	#endregion

	#region My Functions

	private void ChangePlayerColor(bool edged)
	{
		if (edged)
		{
			PlayerMat.SetColor("Color_E24EE7F2", Edge);
		}
		else
		{
			PlayerMat.SetColor("Color_E24EE7F2", Normal);
		}
	}

	#endregion
}
