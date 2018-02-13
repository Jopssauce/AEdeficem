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

	public int waterSum;
	public int foodSum;
	public int powerSum;
	public int actionPointsSum;

    public List<int> ResourceSpent;

	public int currentRQSum;
	public int maxRQSum;

    private RegionManager regManager;

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

    public bool CheckResources(GameObject Event)
    {
        List<int> CurrentResource = new List<int>();
        CurrentResource.Add(water);
        CurrentResource.Add(food);
        CurrentResource.Add(power);
        CurrentResource.Add(actionPoints);

        List<int> ResourceRequirement = new List<int>();
        ResourceRequirement.Add(Event.GetComponent<EventPopUpBase>().eventData.waterCost);
        ResourceRequirement.Add(Event.GetComponent<EventPopUpBase>().eventData.foodCost);
        ResourceRequirement.Add(Event.GetComponent<EventPopUpBase>().eventData.powerCost);
        ResourceRequirement.Add(Event.GetComponent<EventPopUpBase>().eventData.actionCost);

        for (int i = 0; i < ResourceSpent.Count; i++)
        {
            Debug.Log(ResourceSpent[i]);
            if ((ResourceSpent[i] + ResourceRequirement[i]) < CurrentResource[i])
            {
                ResourceSpent[i] += ResourceRequirement[i];
            }
            else
            {
                return false;
            }
        }

        return true;
    }

	public void GetResourceSum()
	{
		waterSum 		= 0;
		foodSum 		= 0;
		powerSum 		= 0;
		actionPointsSum = 0;
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
	public bool isEnoughRes(int waterCost, int foodCost, int powerCost, int actionCost)
	{
		if (water < waterCost || food < foodCost || power < powerCost || actionPoints < actionCost)
		{
			return false;
		}
		else
		{
			return true;
		}
		
	}
  
}
