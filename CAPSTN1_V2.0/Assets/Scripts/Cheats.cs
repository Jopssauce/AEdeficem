using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour {

	private RegionManager regionManager;
	private ResourceManager resourceManager;
	public int Addition;
	// Use this for initialization
	void Start()
	{
		if (ResourceManager.instance != null)
		{
			resourceManager = ResourceManager.instance;
		}

		if (RegionManager.instance != null)
		{
			regionManager = RegionManager.instance;
		}
	}
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.F1))
		{
			IncreaseCityResource ();
		}
		if (Input.GetKeyDown (KeyCode.F2)) 
		{
			IncreaseTheAP ();
		}
	}

	void IncreaseTheAP()
	{
		resourceManager.actionPoints = 10;
		resourceManager.AdjustedResourceEvent.Invoke ();
	}

	void IncreaseCityResource()
	{
		foreach (RegionBase s in regionManager.regionList)
		{
			s.cityOrigin.GetComponent<CityBase> ().cityResources.Water += Addition;
			s.cityOrigin.GetComponent<CityBase> ().cityResources.Food += Addition;
			s.cityOrigin.GetComponent<CityBase> ().cityResources.Power += Addition;
			s.cityOrigin.GetComponent<CityBase> ().AdjustedCityResource.Invoke ();
		}
	}
}
