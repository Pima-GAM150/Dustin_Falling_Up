using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
	#region Variables

	[Range(0,5),Tooltip("How Hard the wind is blowing")]
	public float Strength;

	[Tooltip("The direction the wind will push an object")]
	public Vector3 WindDirection;

	[Range(0,10),Tooltip("How long till the wind changes direction")]
	public float TimeBetweenChanges;
	
	#endregion
	
	#region Unity Functions
	
	private void Start()
	{
		StartCoroutine("WindChange");		
	}

	private void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag!="Player")
			other.GetComponent<Rigidbody>().AddForce(WindDirection.normalized * Strength, ForceMode.Impulse);	
	}
	#endregion

	#region My Functions

	/// <summary>
	/// 
	/// waits for a certian amount of time and then calls the ChangeDirection() function
	/// 
	/// </summary>
	/// <returns></returns>
	private IEnumerator WindChange()
	{
		while(true)
		{
			yield return new WaitForSeconds(TimeBetweenChanges);

			ChangeDirection();
		}
	}

	/// <summary>
	///
	/// will set the wind direction vector to a random vector in the x,y plane 
	/// 
	/// </summary>
	private void ChangeDirection()
	{
		var rndX = Random.Range(-256, 256);
		var rndY = Random.Range(-256, 256);

		WindDirection = new Vector3(rndX, rndY, 0).normalized;
	}

	#endregion
}
