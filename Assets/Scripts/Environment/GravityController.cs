using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
	#region Variables

	public static GravityController Instance;
	
	public enum GravityDirection
	{
		NORTH,EAST,SOUTH,WEST,
		NORTH_EAST,NORTH_WEST,
		SOUTH_EAST,SOUTH_WEST
	}

	public GravityDirection GravDir;

	[Range(0,20),Tooltip("How fast the environment moves around you")]
	public float Gravitation;

	[Range(0, 20), Tooltip("How fast the environment moves around you")]
	public float DirChangeTime;

	private Vector3 GravityVector;


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
			Destroy(this);
		}
	}

	private void Start()
	{
		ChangeGravityDirecetion(GravDir);
	}

	private void Update()
	{
		
	}

	private void OnDestroy()
	{
		
	}
	#endregion

	#region My Functions

	/// <summary>
	/// 
	/// 
	/// 
	/// </summary>
	public Vector3 ChangeGravityDirecetion(int num)
	{
		switch (num % 8)
		{
			case 0:
				return new Vector3(0, 1, 0);
			case 1:
				return new Vector3(1, 1, 0);
			case 2:
				return new Vector3(-1, 1, 0);
			case 3:
				return new Vector3(0, -1, 0);
			case 4:
				return new Vector3(1, -1, 0);
			case 5:
				return new Vector3(-1, -1, 0);
			case 6:
				return new Vector3(-1, 0, 0);
			case 7:
				return new Vector3(1, 0, 0);
			default:
				return Vector3.zero;
		}
	}

	/// <summary>
	/// 
	/// 
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
	/// 
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
