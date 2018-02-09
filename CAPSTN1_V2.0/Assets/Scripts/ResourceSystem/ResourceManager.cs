using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	public int currentRQSum;
	public int maxRQSum;

    private RegionManager RegionMngrReference;

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
	}

    void Start()
    {
        Invoke("DelayAssign",0.3f);
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
	}

	public void GetRegionQualitySum()
	{
		//Get list of regions
		//Get get Max and Current Region Quality 
		//Normalize/Percentage it
	}

	public void GetResourceSum()
	{
		//Get total amount of resource that can be lost/gained every turn
	}

	public void ReplenishResource()
	{
        foreach (var item in RegionMngrReference.regionList)
        {
            AddResource(item.GetComponent<RegionBase>().RegionType, item.GetComponent<RegionBase>().RegionResourceAmount);
        }
	}

    public void DelayAssign()
    {
        RegionMngrReference = RegionManager.instance;
    }
}
