using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
	#region Variables

	[Tooltip("Block Options to be Spawned")]
	GameObject[] Blocks;

	[Range(0,10),Tooltip("")]
	public float TimeBetweenSpawns;

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
	
	/// <summary>
	/// 
	/// </summary>
	private void InstantiateRandomBlock()
	{

	}

	/// <summary>
	/// 
	/// </summary>
	/// <returns></returns>
	private IEnumerator TimeBetweenBlockSpawns()
	{
		while(true)
		{
			yield return new WaitForSeconds(TimeBetweenSpawns);

			InstantiateRandomBlock();
		}
	}

	private IEnumerator ReduceTimeBetweenBlocks(float time)
	{
		while(true)
		{
			yield return new WaitForSeconds(time);

			TimeBetweenSpawns *= .90f;
		}
	}
	
	#endregion
}
