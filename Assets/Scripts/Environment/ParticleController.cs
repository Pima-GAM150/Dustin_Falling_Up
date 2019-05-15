using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
	#region Variables

	[Tooltip("The particle system children on this game object")]
	public List<ParticleSystem> ParticleEffects;

	[Range(0, 4), Tooltip("Number of Active Particle Systems")]
	public int NumberON;

	[Range(0,5),Tooltip("How long between random Switches of how many are on")]
	public float SwitchTime;
	
	#endregion
	
	#region Unity Functions
	
	private void Start()
	{
		foreach(ParticleSystem ps in ParticleEffects)
		{
			ps.gameObject.SetActive(false);
		}

		StartCoroutine("RandomActivate");
	}
	
	#endregion
	
	#region My Functions
	
	/// <summary>
	/// 
	/// sets random activation of the diff particle systems on a timer
	/// 
	/// </summary>
	/// <returns></returns>
	private IEnumerator RandomActivate()
	{
		while(true)
		{
			yield return new WaitForSeconds(SwitchTime);

			RandomActivator();
		}
	}

	/// <summary>
	/// 
	/// Pics a random number of particle sstems that should be turned on and 
	/// then turns all of them off 
	/// next will pick a random index and activate if as many times as the 
	/// first random number of systems that should be activated 
	/// 
	/// </summary>
	private void RandomActivator()
	{
		NumberON = Random.Range(0,4);

		foreach (ParticleSystem ps in ParticleEffects)
		{
			ps.gameObject.SetActive(false);
		}

		for (int i = 0; i < NumberON; i++)
		{
			var index = Random.Range(0, ParticleEffects.Capacity);

			ParticleEffects[index].gameObject.SetActive(true);

			ParticleEffects[index].Play();
		}
	}
	
	#endregion
}