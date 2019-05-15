using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
	#region Variables
	
	
	
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
        
	}

	#endregion

	#region My Functions

	public void LoadGame()
	{
		SceneManager.LoadScene("Level",LoadSceneMode.Single);
		SceneManager.LoadScene("Level Environment", LoadSceneMode.Additive);
		
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void Pause()
	{
		
	}

	public void Resume()
	{

	}

	#endregion
}
