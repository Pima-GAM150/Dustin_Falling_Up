using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	#region Variables

	[Range(0, 30), Tooltip("Speed Multiplier in the 'X' Direction")]
	public float HorizSpeed;

	[Range(0, 30), Tooltip("Speed Multiplier in the 'Y' Direction")]
	public float VertSpeed;


	private Rigidbody rb;


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
		transform.position += new Vector3 (Input.GetAxis("Horizontal")*HorizSpeed, Input.GetAxis("Vertical")*VertSpeed, 0)*Time.deltaTime;
	}
	
	#endregion
	
	#region My Functions
	
	#endregion
}
