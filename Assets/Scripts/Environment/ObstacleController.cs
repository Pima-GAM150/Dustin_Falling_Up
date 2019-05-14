using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Dustin;

public class ObstacleController : MonoBehaviour
{
	#region Variables

	[Tooltip("Block Options to be Spawned")]
	public List<GameObject> Blocks;

	[Tooltip("Places to spawn blocks from")]
	public List<SpawnPoint> Spawns;

	[Range(0,10),Tooltip("How long after a block is spawned that another will be spawned")]
	public float TimeBetweenSpawns;

	private float resetTime;

	#endregion

	#region Unity Functions

	private void Awake()
	{
		resetTime = TimeBetweenSpawns;
	}
	
	private void Start()
	{
		StartCoroutine("TimeBetweenBlockSpawns");
	}
	
	private void Update()
	{
        
	}

	#endregion

	#region My Functions

	/// <summary>
	/// 
	/// pick a block form the array of blocks and spawn it from a point off screen
	/// based on the gravity direction and with the gravity vector
	/// 
	/// </summary>
	private void InstantiateRandomBlock()
	{
		var randSpawnIndex = Random.Range(0, 256) % 25;

		var blockToSpawn = Instantiate(Blocks[randSpawnIndex]);

		var spawnPoint = Spawns.Find(item => item.SpawnDir == GravityController.Instance.GravDir);

		blockToSpawn.GetComponent<Rigidbody>().velocity = GravityController.Instance.GravityVector * GravityController.Instance.Gravitation;

		blockToSpawn.transform.position = spawnPoint.transform.position;
	}

	/// <summary>
	/// 
	/// timer to wait to spawn a block
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

	/// <summary>
	/// 
	/// timer to reduce theamount of time between spawns
	/// 
	/// </summary>
	/// <param name="time"></param>
	/// <returns></returns>
	private IEnumerator ReduceTimeBetweenBlocks(float time)
	{
		while(true)
		{
			yield return new WaitForSeconds(time);

			TimeBetweenSpawns *= .90f;
		}
	}

	/// <summary>
	/// 
	/// reset times used in spawn timer when gravity is changed
	/// 
	/// </summary>
	public void OnGravitychange()
	{
		TimeBetweenSpawns = resetTime;
	}
	
	#endregion
}
