﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {
	public static TurnManager 	instance = null;
	public ResourceManager 		resManager;
	public EventManager 		eventManager;
	public RegionManager		regionManager;
	
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
	}

	public void AdvanceTurn()
	{
		if (isTurnEnded == true) 
		{
			//Replenish Resources
			if (resManager != null)
			{
				resManager.ReplenishResource();
			}
			//Event Timer goes down
			//Check for solved/Unresolved
			//Spawn Event if limit is not reached
			if (eventManager != null)
			{
				if (eventManager.eventTracker != null)
				{
						
					if (eventManager.eventTracker.Count != 10)
					{
						eventManager.SpawnEvent();
					}
					
					foreach (var item in eventManager.eventTracker.ToArray())
					{
						EventData eventData = item.GetComponent<EventPopUpBase> ().eventData;

						if (eventData.isResolved == true)
						{
                            Destroy(item.gameObject);
                           //eventManager.eventTracker.Remove(item);
						}
						if (eventData.isResolved == false)
						{
							//eventData.turnsLeft -= 1;
							Debug.Log(eventData.turnsLeft);
							if (eventData.turnsLeft <= 0)
							{
								//Deduct quality to regions
								if (regionManager != null)
								{
									
								}
								
								//Destroy(item.gameObject);
								//eventManager.eventTracker.Remove(item);
							}
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
					RegionBase regionBase = region.GetComponent<RegionBase>();
					regionBase.regionQuality 			-= regionBase.regionQualityDecay * regionBase.maxRegionQuality;
					regionBase.regionResourceAmount 	= Mathf.RoundToInt( (regionBase.regionQuality / regionBase.maxRegionQuality) * regionBase.MaxRegionResource);
					if (regionBase.regionResourceAmount <= 0)
					{
						regionBase.regionResourceAmount = 0;
					}
				}
			}
			//Begin Next Turn
			currentTurn++;
			isTurnEnded = false;
		}
	}
}
