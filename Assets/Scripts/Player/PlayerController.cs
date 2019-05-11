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
	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		SetHorizontalVelocity();
		SetVerticalVelocity();
	}

	#endregion

	#region My Functions

	/// <summary>
	/// 
	/// </summary>
	private void SetHorizontalVelocity()
	{
		if(Input.GetAxis("Horizontal")!=0)
		{
			rb.velocity = new Vector3(Input.GetAxis("Horizontal")*HorizSpeed,rb.velocity.y,0);
		}
		else
		{
			rb.velocity = new Vector3(0, rb.velocity.y, 0);
		}
	}

	/// <summary>
	/// 
	/// </summary>
	private void SetVerticalVelocity()
	{
		if (Input.GetAxis("Vertical") != 0)
		{
			rb.velocity = new Vector3(rb.velocity.x, Input.GetAxis("Vertical") * VertSpeed, 0);
		}
		else
		{
			rb.velocity = new Vector3(rb.velocity.x, 0, 0);
		}
	}
	#endregion
}
