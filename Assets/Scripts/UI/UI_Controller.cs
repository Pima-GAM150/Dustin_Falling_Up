using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
	#region Variables

	private float currentGravitation;
	
	#endregion

	#region My Functions

	public void LoadGame()
	{
		SceneManager.LoadScene("Level",LoadSceneMode.Single);
		SceneManager.LoadScene("Level Environment", LoadSceneMode.Additive);
		
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("Main Menu");
	}

	public void Quit()
	{
		Application.Quit();
	}
	public void Pause()
	{
		PlayerController.Instance.isPaused = true;

		currentGravitation = GravityController.Instance.Gravitation;

		GravityController.Instance.Gravitation = 0;
	}

	public void Resume()
	{
		PlayerController.Instance.isPaused = false;

		GravityController.Instance.Gravitation = currentGravitation;
	}

	#endregion
}