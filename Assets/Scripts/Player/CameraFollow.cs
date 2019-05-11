using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	#region Variables

	[Tooltip("What is being followed.")]
	public Transform Target;

	[Range(0, 15), Tooltip("The distance away from the target.")]
	public float Z_Offset;

	[Range(0, 1), Tooltip("How smooth the movement is of the camera towards the target.")]
	public float Smoothing;
		
	#endregion
	
	#region Unity Functions
    
	private void FixedUpdate()
	{
		var position = Vector3.Lerp(transform.position, Target.position - new Vector3(0, 0, Z_Offset), Smoothing * Time.deltaTime);

		transform.position = position;

		transform.LookAt(Target);
	}
	
	#endregion
	
	#region My Functions
	
	
	
	#endregion
}
