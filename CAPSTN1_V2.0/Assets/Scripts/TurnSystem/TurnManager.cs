using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TurnManager : MonoBehaviour {
	public static TurnManager 	instance = null;
	public ResourceManager 		resManager;
	public EventManager 		eventManager;
	public RegionManager		regionManager;
	public AQManager 			aqManager;
	
	public float 				currentTurn;
	public bool 				isTurnEnded;
	public bool 				victory;
	public bool 				defeat;

	public int 					sustainableRegions;

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
		victory = true;
		defeat = true;
		AdvanceTurn();
		
	}

	public void AdvanceTurn()
	{
		currentTurn++;
		sustainableRegions = 0;
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
							eventPopUp.regionOrigin.GetComponent<RegionBase>().regionQuality += eventPopUp.eventData.qualityDecay * eventPopUp.regionOrigin.GetComponent<RegionBase>().maxRegionQuality;

                        	Destroy(item.gameObject);

                           	eventManager.eventTracker.Remove(item);
						}
						if (eventPopUp.isResolved == false)
						{
							eventPopUp.turnsLeft -= 1;

							if (eventPopUp.turnsLeft > 0)
							{
								eventPopUp.GetComponent<Image>().sprite = eventPopUp.timerSprites[eventPopUp.turnsLeft - 1];	
							}
							if (eventPopUp.turnsLeft <= 0)
							{
								Destroy(item.gameObject);
								eventManager.eventTracker.Remove(item);
							}
						}
					}
					for (int i = 0; i < 3; i++)
					{
						if (eventManager.eventTracker.Count != 5)
						{
							if (currentTurn >= 0 && currentTurn < 20)
							{
								eventManager.SpawnEvent(EventData.EventTier.Tier1);
							}
							else if (currentTurn >= 20 && currentTurn < 40)
							{
								Debug.Log("SPawned tier2");
								eventManager.SpawnEvent(EventData.EventTier.Tier2);
							}
							else if (currentTurn >= 40)
							{
								eventManager.SpawnEvent(EventData.EventTier.Tier3);
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
					RegionBase regionBase 				= region.GetComponent<RegionBase>();
					regionBase.regionQuality 			-= regionBase.regionQualityDecay * regionBase.maxRegionQuality;
					regionBase.regionResourceAmount 	= Mathf.RoundToInt( (regionBase.regionQuality / regionBase.maxRegionQuality) * regionBase.MaxRegionResource);
					regionBase.material.color 			= Color.Lerp(Color.red, Color.cyan, regionBase.regionQuality / regionBase.maxRegionQuality);
					if (regionBase.regionResourceAmount <= 0)
					{
						regionBase.regionResourceAmount = 0;
					}
					if (regionBase.regionQuality > regionBase.maxRegionQuality)
					{
						regionBase.regionQuality = regionBase.maxRegionQuality;
					}
				}

				bool isVictory;
				if (currentTurn >= 50)
				{
				if (regionManager.regionList.All(region => region.GetComponent<RegionBase>().regionQuality >= 90))
					{
						isVictory = true;
						//Victory Scene
						PlayerPrefs.SetString("isVictory", isVictory.ToString());
						SceneManager.LoadScene("Victory Scene");
					}
				}
				
				if (regionManager.regionList.All(region => region.GetComponent<RegionBase>().regionQuality <= 0))
				{
					isVictory = false;
					//Defeat Scene
					PlayerPrefs.SetString("isVictory", isVictory.ToString());
					SceneManager.LoadScene("Victory Scene");
				}
			}
            for (int i = 0; i < ResourceManager.instance.ResourceSpent.Count; i++)
            {
                ResourceManager.instance.ResourceSpent[i] = 0;
            }
			//Begin Next Turn
			
			isTurnEnded = false;
		}
		
	}
	
}