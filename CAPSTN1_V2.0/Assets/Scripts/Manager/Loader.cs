using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {
	public GameObject resourceManager;
	public GameObject eventManager;
	public GameObject regionManager;
	public GameObject turnManager;
	public GameObject researchManager;
	public GameObject audioManager;

	void Awake()
	{
		if (ResourceManager.instance == null) 
		{
			Instantiate (resourceManager);
		}
		if (EventManager.instance == null) 
		{
			Instantiate (eventManager);
		}
		if (RegionManager.instance == null) 
		{
			Instantiate (regionManager);
		}
		if (TurnManager.instance == null)
		{
			Instantiate (turnManager);
		}
		if (ResearchManager.instance == null)
		{
			Instantiate (researchManager);
		}

		if (AudioManager.instance == null)
		{
			Instantiate (audioManager);
		}
	}
}
