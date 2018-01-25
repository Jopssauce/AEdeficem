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


}
