﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResourceManager : MonoBehaviour {

	public static ResourceManager instance = null;
	public enum ResourceType
	{
		Water,
		Food,
		Power,
		ActionPoints
	}

	public int water;
	public int food;
	public int power;
	public int actionPoints;

	public int waterSum;
	public int foodSum;
	public int powerSum;
	public int actionPointsSum;

    public List<int> ResourceSpent;

	public int currentRQSum;
	public int maxRQSum;

    private RegionManager regManager;
	public UnityEvent AdjustedResourceEvent;
	
	void Awake()
	{
		if (instance == null) 
		{
			instance = this;	
		}
		else if (instance != this) 
		{
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);

        ResourceSpent = new List<int>();
        ResourceSpent.Add(0);
        ResourceSpent.Add(0);
        ResourceSpent.Add(0);
        ResourceSpent.Add(0);

    }

    void Start()
    {
        if (RegionManager.instance != null)
		{
			regManager = RegionManager.instance;
		}
		water 			= 10;
		food 			= 10;
		power 			= 10;
		actionPoints 	= 10;
		
    }

    public void AddResource(ResourceType type, int amount)
	{
		switch (type) 
		{
		case ResourceType.ActionPoints:
			actionPoints 	+= amount;
			break;
		case ResourceType.Food:
			food 			+= amount;
			break;
		case ResourceType.Power:
			power			+= amount;
			break;
		case ResourceType.Water:
			water 			+= amount;
			break;
		default:
			Debug.Log ("Cant add Resource");
			break;
		}
		AdjustedResourceEvent.Invoke ();
	}

	public void DeductResource(ResourceType type, int amount)
	{
		switch (type) 
		{
		case ResourceType.ActionPoints:
			actionPoints 	-= amount;
			break;
		case ResourceType.Food:
			food 			-= amount;
			break;
		case ResourceType.Power:
			power 			-= amount;
			break;
		case ResourceType.Water:
			water 			-= amount;
			break;
		default:
			Debug.Log ("Cant deduct Resource");
			break;
		}
		AdjustedResourceEvent.Invoke ();
	}
		
	public void GetResourceSum()
	{
		waterSum 		= 0;
		foodSum 		= 0;
		powerSum 		= 0;
		foreach (var region in regManager.regionList)
        {
          switch (region.GetComponent<RegionBase>().regionType)
		  {
			  case ResourceType.Water:
			  	waterSum 		+= region.GetComponent<RegionBase>().regionResourceAmount;
				break;	
			  case ResourceType.Food:
			  	foodSum 		+= region.GetComponent<RegionBase>().regionResourceAmount;
				break;
			  case ResourceType.Power:
			  	powerSum 		+= region.GetComponent<RegionBase>().regionResourceAmount;
				break;
			  case ResourceType.ActionPoints:
			  	actionPointsSum += region.GetComponent<RegionBase>().regionResourceAmount;
				break;
			  default:
			  Debug.Log ("error region quality sum");
			  break;
		  }  
        }
	}

	public void ReplenishResource()
	{
        foreach (var item in regManager.regionList)
        {
            AddResource(item.GetComponent<RegionBase>().regionType, item.GetComponent<RegionBase>().regionResourceAmount);
        }
	}
	public bool isEnoughRes(GameObject Event)
	{
		if (water < Event.GetComponent<EventPopUpBase>().eventData.waterCost || food < Event.GetComponent<EventPopUpBase>().eventData.foodCost 
		 || power < Event.GetComponent<EventPopUpBase>().eventData.powerCost || actionPoints < Event.GetComponent<EventPopUpBase>().eventData.actionCost)
		{
			return false;
		}
		else
		{
			return true;
		}
		
	}
	public void UpdateResources()
	{
		ReplenishResource();
		GetResourceSum();
		AdjustedResourceEvent.Invoke ();
	}
  
}
