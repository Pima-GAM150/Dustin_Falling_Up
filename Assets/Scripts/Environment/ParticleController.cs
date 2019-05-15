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

    
	private void Update()
	{
        
	}
	
	#endregion
	
	#region My Functions
	
	private IEnumerator RandomActivate()
	{
		while(true)
		{
			yield return new WaitForSeconds(SwitchTime);

			RandomActivator();
		}
	}

	private void RandomActivator()
	{

	}
	
	#endregion
}
