/*
 * 
 *		Camera follow a target 
 * 
 *		could be renamed to follow any obj
 * 
 */

using System.Collections;
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

	[Range(0, 15), Tooltip("How long before it will wait to rotate the Camera again.")]
	public float Timer;

	#endregion

	#region Unity Functions

	private void Start()
	{
		StartCoroutine("RotateCam");
	}

	private void FixedUpdate()
	{
		var position = Vector3.Lerp(transform.position, Target.position - new Vector3(0, 0, Z_Offset), Smoothing);

		transform.position = position;
	}
	
	#endregion
	
	#region My Functions
	
	/// <summary>
	/// 
	/// waits 10 seconds then calls a funcion that randomly rotates the camera by a multiple 30(Degrees)
	/// 
	/// </summary>
	/// <returns></returns>
	private IEnumerator RotateCam()
	{
		while(true)
		{
			yield return new WaitForSeconds(Timer);

			RndRotate();
		}
	}

	/// <summary>
	/// 
	/// Rotate the camera by a random Multiple of 30
	/// 
	/// </summary>
	private void RndRotate()
	{
		transform.Rotate(transform.forward, (Random.Range(-4, 4) % 3 * 30));
	}
	#endregion
}