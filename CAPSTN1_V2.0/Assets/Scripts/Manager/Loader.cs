using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {
	public GameObject resourceManager;
	public GameObject eventManager;
	public GameObject regionManager;

	public List<GameObject> managers;

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
	}
}
