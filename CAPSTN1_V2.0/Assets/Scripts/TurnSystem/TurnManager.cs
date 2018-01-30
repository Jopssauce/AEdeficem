using System.Collections;
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
				if (eventManager.EventList != null)
				{
						
					if (eventManager.EventList.Count != 10)
					{
						eventManager.SpawnEvent();
					}
					
					foreach (var item in eventManager.EventList.ToArray())
					{
						EventPopUpBase eventPopUp = item.GetComponent<EventPopUpBase> ();

						if (eventPopUp.ResolveOnEnd == true)
						{
							eventManager.EventList.Remove(item);
						}
						if (eventPopUp.ResolveOnEnd == false)
						{
							eventPopUp.TurnsBeforeFail -= 1;

							if (eventPopUp.TurnsBeforeFail <= 0)
							{
								//Deduct quality to regions
								if (regionManager != null)
								{
									
								}
								eventManager.EventList.Remove(item);
							}
						}
					}	
				}
			}
			
			//Check for collpasing Regions
			//Update region special resource
			if (regionManager != null)
			{
				foreach (var item in regionManager.RegionList)
				{
					//If region quality is low. Lower resource gain from region
				}
			}
			//Begin Next Turn
			currentTurn++;
			isTurnEnded = false;
		}
	}
}
