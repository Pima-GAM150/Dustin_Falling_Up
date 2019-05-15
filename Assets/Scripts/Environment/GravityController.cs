using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Dustin;

public class GravityController : MonoBehaviour
{
	#region Variables

	public static GravityController Instance;

	public GravityChangeEvent GravChanged;

	[Tooltip("Direction of movement as a Cardinal direction named value")]
	public GravityDirection GravDir;

	[Range(0,20),Tooltip("How fast the environment moves around you")]
	public float Gravitation;
	
	[Tooltip("Direction of movement in world space as a vector")]
	public Vector3 GravityVector;


	#endregion
	
	#region Unity Functions
	
	private void Awake()
	{
		if(Instance==null)
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
		GravityVector = ChangeGravityDirecetion(GravDir);

		GravChanged?.Invoke(GravityVector);

		PlayerController.Instance.SwitchTimerStart.AddListener(StartDirChangeTimer);
	}

	private void OnDestroy()
	{
		PlayerController.Instance.SwitchTimerStart.RemoveListener(StartDirChangeTimer);
	}

	#endregion

	#region My Functions

	/// <summary>
	/// 
	/// pics a random Dirrection for the gravitation vector
	/// 
	/// </summary>
	public Vector3 ChangeGravityDirecetion(int num)
	{
		switch (num % 8)
		{
			case 0:
				GravDir = GravityDirection.NORTH;
				return new Vector3(0, 1, 0);
			case 1:
				GravDir = GravityDirection.NORTH_EAST;
				return new Vector3(1, 1, 0);
			case 2:
				GravDir = GravityDirection.NORTH_WEST;
				return new Vector3(-1, 1, 0);
			case 3:
				GravDir = GravityDirection.SOUTH;
				return new Vector3(0, -1, 0);
			case 4:
				GravDir = GravityDirection.SOUTH_EAST;
				return new Vector3(1, -1, 0);
			case 5:
				GravDir = GravityDirection.SOUTH_WEST;
				return new Vector3(-1, -1, 0);
			case 6:
				GravDir = GravityDirection.WEST;
				return new Vector3(-1, 0, 0);
			case 7:
				GravDir = GravityDirection.EAST;
				return new Vector3(1, 0, 0);
			default:
				return Vector3.zero;
		}
	}

	/// <summary>
	/// 
	/// switches to a specific Gravitation Vector
	/// 
	/// </summary>
	/// <param name="dir"></param>
	/// <returns></returns>
	public Vector3 ChangeGravityDirecetion(GravityDirection dir)
	{
		switch (dir)
		{
			case GravityDirection.NORTH:
				return new Vector3(0, 1, 0);

			case GravityDirection.NORTH_EAST:
				return new Vector3(1, 1, 0);

			case GravityDirection.NORTH_WEST:
				return new Vector3(-1, 1, 0);

			case GravityDirection.SOUTH:
				return new Vector3(0, -1, 0);

			case GravityDirection.SOUTH_EAST:
				return new Vector3(1, -1, 0);

			case GravityDirection.SOUTH_WEST:
				return new Vector3(-1, -1, 0);

			case GravityDirection.WEST:
				return new Vector3(-1, 0, 0);

			case GravityDirection.EAST:
				return new Vector3(1, 0, 0);

			default:
				return Vector3.zero;
		}
	}
		
	/// <summary>
	/// 
	/// timer to set the gravity direction randomly 
	/// 
	/// </summary>
	/// <param name="time"></param>
	/// <returns></returns>
	private IEnumerator TimeBetweenDirChange(float time)
	{
		while(time>0)
		{
			yield return new WaitForSeconds(time);

			time--;
		}

		var RandNum = Random.Range(0,256);

		GravityVector = ChangeGravityDirecetion(RandNum);

		GravChanged?.Invoke(GravityVector);
	}

	/// <summary>
	/// 
	/// Starts coroutine when called 
	/// 
	/// in a seperate function in order to call from event with a dynamic integer
	/// 
	/// </summary>
	public void StartDirChangeTimer(float time)
	{
		StartCoroutine("TimeBetweenDirChange", time);
	}

	#endregion
}


namespace UnityEngine.Dustin
{
	public enum GravityDirection
	{
		NORTH, EAST, SOUTH, WEST,
		NORTH_EAST, NORTH_WEST,
		SOUTH_EAST, SOUTH_WEST
	}

	[System.Serializable]
	public class GravityChangeEvent: Events.UnityEvent<Vector3>
	{
		//sends the gravitation vector so all the blocks can change the flow direction
	}
}
