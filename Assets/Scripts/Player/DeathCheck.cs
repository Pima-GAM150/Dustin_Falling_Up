using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCheck : MonoBehaviour
{
	#region Variables
	
	
	
	#endregion
	
	#region Unity Functions
	    
	private void Update()
	{
        if(PlayerController.Instance.Health<=0)
		{
			SceneManager.LoadScene("Fail");
		}
	}
	
	#endregion
	
	#region My Functions
	
	
	
	#endregion
}
