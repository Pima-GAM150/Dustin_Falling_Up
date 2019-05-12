/*
 * 
 * Velocity based player movement in "x" & "y" directions
 * 
 */
using UnityEngine;
using UnityEngine.Dustin;

public class PlayerController : MonoBehaviour
{
	#region Variables

	public static PlayerController Instance;

	[Range(0, 30), Tooltip("Speed Multiplier in the 'X' Direction")]
	public float HorizSpeed;

	[Range(0, 30), Tooltip("Speed Multiplier in the 'Y' Direction")]
	public float VertSpeed;

	[Range(0, 20), Tooltip("Max Distance from (0,0)")]
	public float Xdist, Ydist;

	[Range(0, 5), Tooltip("amount of time sent with the Switch Timer Start Event")]
	public float AmountOfTime;

	[Tooltip(" Event to start a countdown to change the\n movement direction of the environment")]
	public UnityFloatEvent SwitchTimerStart;

	private Rigidbody rb;

	#endregion

	#region Unity Functions

	private void Awake()
	{

		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(this.gameObject);
		}
	}

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		GravityChangerInput();

		RestrainPlayerMovement();
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
	/// Checks for 'a', 'd', 'left', or 'right'(arrows) input to get the direction of movement
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
	/// Checks for 'w', 's', 'up', or 'down' (arrows) input to get the direction of movement
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

	/// <summary>
	/// 
	/// keep player in a smaller region while the environment moves around you
	/// 
	/// </summary>
	private void RestrainPlayerMovement()
	{
		var clampedX = Mathf.Clamp(transform.position.x,-Xdist,Xdist);

		var clampedY = Mathf.Clamp(transform.position.y, -Ydist, Ydist);

		transform.position = new Vector3(clampedX, clampedY, 0);
	}

	/// <summary>
	/// 
	/// Checks for space bar or left mouse button to change the gravity direction
	/// 
	/// </summary>
	private void GravityChangerInput()
	{
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
		{
			Debug.Log("Starting timer");

			SwitchTimerStart?.Invoke(AmountOfTime);
		}
	}

	#endregion
}

namespace UnityEngine.Dustin
{
	[System.Serializable]
	public class UnityFloatEvent : Events.UnityEvent<float>
	{

	}
}