using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {
	public static TurnManager 	instance = null;
	public ResourceManager 		resManager;
	public EventManager 		eventManager;
	public RegionManager		regionManager;
	public AQManager 			aqManager;
	
	public float 				currentTurn;
	public int 					turns;
	public bool 				isTurnEnded;

	void Awake()
	{
		if (instance == null) 
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy (this.gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}
	
	void Start()
	{
		if (ResourceManager.instance != null)
		{
			resManager = ResourceManager.instance;
		}
		if (EventManager.instance != null)
		{
			eventManager = EventManager.instance;
		}
		if (RegionManager.instance != null)
		{
			regionManager = RegionManager.instance;
		}
        if (AQManager.instance != null)
        {
            aqManager = AQManager.instance;
        }
		resManager.GetResourceSum();
	}

	public void AdvanceTurn()
	{
		if (isTurnEnded == true) 
		{
			//Replenish Resources
			if (resManager != null)
			{
				resManager.ReplenishResource();
				resManager.GetResourceSum();
			}
			//Event Timer goes down
			//Check for solved/Unresolved
			//Spawn Event if limit is not reached
			if (eventManager != null)
			{
				if (eventManager.eventTracker != null)
				{
					foreach (var item in eventManager.eventTracker.ToArray())
					{
						EventPopUpBase eventPopUp = item.GetComponent<EventPopUpBase>();
						if (item.GetComponent<EventPopUpBase> ().isResolved == true)
						{
							resManager.DeductResource(ResourceManager.ResourceType.ActionPoints, eventPopUp.eventData.actionCost);
							resManager.DeductResource(ResourceManager.ResourceType.Water,	eventPopUp.eventData.waterCost);
							resManager.DeductResource(ResourceManager.ResourceType.Power, 	eventPopUp.eventData.powerCost);
							resManager.DeductResource(ResourceManager.ResourceType.Food, 	eventPopUp.eventData.foodCost);

							eventPopUp.regionOrigin.GetComponent<RegionBase>().regionQuality += eventPopUp.eventData.qualityDecay * eventPopUp.regionOrigin.GetComponent<RegionBase>().maxRegionQuality;

                        	Destroy(item.gameObject);

                           	eventManager.eventTracker.Remove(item);
						}
						if (item.GetComponent<EventPopUpBase> ().isResolved == false)
						{
							item.GetComponent<EventPopUpBase> ().turnsLeft -= 1;
							if (item.GetComponent<EventPopUpBase> ().turnsLeft <= 0)
							{
								//Deduct quality to regions
								if (regionManager != null)
								{
									
								}
								Destroy(item.gameObject);
								eventManager.eventTracker.Remove(item);
							}
						}
					}
					for (int i = 0; i < 3; i++)
					{
						if (eventManager.eventTracker.Count != 10)
						{
							eventManager.SpawnEvent();
						}	
					}					
				}
			}
			
			//Check for collpasing Regions
			//Update region special resource
			if (regionManager != null)
			{
				foreach (var region in regionManager.regionList)
				{
					RegionBase regionBase 				= region.GetComponent<RegionBase>();
					regionBase.regionQuality 			-= regionBase.regionQualityDecay * regionBase.maxRegionQuality;
					regionBase.regionResourceAmount 	= Mathf.RoundToInt( (regionBase.regionQuality / regionBase.maxRegionQuality) * regionBase.MaxRegionResource);
					regionBase.material.color = Color.Lerp(Color.red, Color.green, regionBase.regionQuality / regionBase.maxRegionQuality);
					if (regionBase.regionResourceAmount <= 0)
					{
						regionBase.regionResourceAmount = 0;
					}
					if (regionBase.regionQuality > regionBase.maxRegionQuality)
					{
						regionBase.regionQuality = regionBase.maxRegionQuality;
					}
				}
			}
            for (int i = 0; i < ResourceManager.instance.ResourceSpent.Count; i++)
            {
                ResourceManager.instance.ResourceSpent[i] = 0;
            }
			//Begin Next Turn
			currentTurn++;
			isTurnEnded = false;
		}
	}
}