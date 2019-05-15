using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Block : MonoBehaviour
{
	#region Variables
	
	
	
	#endregion
	
	#region Unity Functions
	
	private void Start()
	{
		GravityController.Instance.GravChanged.AddListener(OnGravityChanged);
	}

	private void Update()
	{
		if(Vector3.Magnitude((transform.position - PlayerController.Instance.transform.position))>30)
		{
			Destroy(gameObject,.5f);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Player" && !PlayerController.Instance.isPaused)
		{
			PlayerController.Instance.Health -= (transform.localScale.x + transform.localScale.y) / 2f;
		}
	}

	private void OnDestroy()
	{
		GravityController.Instance.GravChanged.RemoveListener(OnGravityChanged);
	}

	#endregion

	#region My Functions

	public void OnGravityChanged(Vector3 newDir)
	{
		GetComponent<Rigidbody>().velocity = newDir * GravityController.Instance.Gravitation;
	}
	
	#endregion
}
