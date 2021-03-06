﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{

	public static EventManager instance = null;
	public GameObject	eventLayer;
    private TurnManager turnManager;
    public GameObject   baseEvent;
	public GameObject	chainEventPrefab;
    public List<GameObject> eventPrefabs;
    public Canvas       newCanvas;
    public GameObject   EventsPanelPrefab;
    public GameObject   EventPanel;
    public EventsList   eventsList;
    
    public GameObject 		eventOutliner;
    public GameObject 		eventOutlinerContent;
	public List<GameObject> eventOutlinerTracker;

    private RegionManager 	RegionManagerInstance;
    public UnityEvent 		ResolvedEvent;
    public UnityEvent 		IgnoredEvent;
	public UnityEvent 		SentUnitEvent;
    public List<GameObject> eventTracker;

    public EventPopUpBase selectedEvent;
    public bool isChainEvent;
	public int maxEvents = 8;

    void Awake()
	{
        newCanvas = Canvas.FindObjectOfType<Canvas>();

		if (instance == null) 
		{
			instance = this;	
		}
		else if (instance != this) 
		{
			Destroy (gameObject);
		}
	}
	void OnDestroy()
	{
		instance = null;
	}

    void Start()
    {
        eventOutliner = GameObject.FindGameObjectWithTag("Event Outliner");
        if (TurnManager.instance != null)
        {
            turnManager = TurnManager.instance;
        }
    }

	public void SpawnEvent(EventData.EventTier eventTier, EventData.EventType eventType)
    {

        RegionManagerInstance = RegionManager.instance;

		int num 	= Random.Range(0 , RegionManagerInstance.regionList.Count);
		int spawnNum = Random.Range(0 ,  RegionManagerInstance.regionList[num].spawnAreas.Count);
		SpawnArea spawnArea = RegionManagerInstance.regionList[num].spawnAreas[spawnNum].GetComponent<SpawnArea>();
		if (eventTracker.Count != maxEvents && spawnArea.eventOrigin == null) 
		{
			GameObject newButton = null;
			if (eventType == EventData.EventType.Standard) 
			{
				newButton = Instantiate(eventPrefabs[0]);	
			}
			else if (eventType == EventData.EventType.Chain) 
			{
				newButton = Instantiate(eventPrefabs[1]);	
			}
			else if (eventType == EventData.EventType.Domino) 
			{
				newButton = Instantiate(eventPrefabs[2]);	
			}


			newButton.transform.SetParent(newCanvas.GetComponent<MainUI>().eventLayer.transform, false);
			newButton.GetComponent<EventPopUpBase>().regionOrigin = RegionManagerInstance.regionList[num];
			newButton.GetComponent<EventPopUpBase>().regionOrigin.spawnAreas[spawnNum].GetComponent<SpawnArea>().eventOrigin = newButton.GetComponent<EventPopUpBase>();
			newButton.GetComponent<BindToRegion>().spawnArea 	  = RegionManagerInstance.regionList[num].spawnAreas[spawnNum];

			switch (eventTier)
			{
			case EventData.EventTier.Tier1:
				newButton.GetComponent<EventPopUpBase>().eventData    = eventsList.tier1Events[Random.Range(0, eventsList.tier1Events.Count)];
				newButton.GetComponent<EventPopUpBase>().eventDataCopy    	  = Instantiate(newButton.GetComponent<EventPopUpBase>().eventData);
				break;
			case EventData.EventTier.Tier2:
				newButton.GetComponent<EventPopUpBase>().eventData    = eventsList.tier2Events[Random.Range(0, eventsList.tier2Events.Count)];
				newButton.GetComponent<EventPopUpBase>().eventDataCopy    	  = Instantiate(newButton.GetComponent<EventPopUpBase>().eventData);
				break;
			case EventData.EventTier.Tier3:
				newButton.GetComponent<EventPopUpBase>().eventData    = eventsList.tier3Events[Random.Range(0, eventsList.tier3Events.Count)];
				newButton.GetComponent<EventPopUpBase>().eventDataCopy    	  = Instantiate(newButton.GetComponent<EventPopUpBase>().eventData);
				break;
			case EventData.EventTier.Tier4:
				newButton.GetComponent<EventPopUpBase>().eventData    = eventsList.tier4Events[Random.Range(0, eventsList.tier4Events.Count)];
				newButton.GetComponent<EventPopUpBase>().eventDataCopy    	  = Instantiate(newButton.GetComponent<EventPopUpBase>().eventData);
				break;
			default:
				Debug.Log("Error tier list");
				break;
			}
			GameObject building = Instantiate(newButton.GetComponent<EventPopUpBase>().eventData.buildingPrefab);
			building.GetComponent<BuildingPrefab>().eventOrigin = newButton.GetComponent<EventPopUpBase>();
			//GameObject newEventContent                                  = Instantiate(eventOutlinerContent);
			//newEventContent.GetComponent<EventContent>().eventOrigin    = newButton.GetComponent<EventPopUpBase>();

			newButton.GetComponent<EventPopUpBase>().turnsLeft          = newButton.GetComponent<EventPopUpBase>().eventData.turnsLeft;
			//eventOutlinerTracker.Add(newEventContent);

			//newEventContent.transform.SetParent(eventOutliner.transform, false);

			eventTracker.Add(newButton);
		}
		
    }
		
    public void UpdateEvents()
    {
		//int standard 	= 0;
		//int chain 		= 0;
		//int domino 		= 0;
		int eventNum 	= Random.Range (2, 5);
	
		if (eventTracker != null)
        {
			for (int i = 0; i < eventNum; i++) 
			{
				if (turnManager.currentTurn >= 0 && turnManager.currentTurn < 20)
				{
					SpawnEvent(EventData.EventTier.Tier1, EventData.EventType.Standard);
				}
				else if (turnManager.currentTurn >= 20 && turnManager.currentTurn < 40)
				{
					SpawnEvent(EventData.EventTier.Tier2, EventData.EventType.Standard);
				}
				else if (turnManager.currentTurn >= 40)
				{
					SpawnEvent(EventData.EventTier.Tier3, EventData.EventType.Standard);
				}   
			}
		}
		/*if (eventNum == 2) 
		{
			standard = 1;
			chain 	= 1;
			domino 	= 0;
		}
		if (eventNum == 3) 
		{
			standard = 1;
			chain 	= 1;
			domino 	= 1;
		}
		if (eventNum == 4) 
		{
			standard = 1;
			chain 	= 1;
			domino 	= 2;
		}
		if (eventNum == 5) 
		{
			standard = 2;
			chain 	= 1;
			domino 	= 2;
		}
        if (eventTracker != null)
        {	
			for (int i = 0; i < standard; i++) 
			{
				if (turnManager.currentTurn >= 0 && turnManager.currentTurn < 20)
				{
					SpawnEvent(EventData.EventTier.Tier1, EventData.EventType.Standard);
				}
				else if (turnManager.currentTurn >= 20 && turnManager.currentTurn < 40)
				{
					SpawnEvent(EventData.EventTier.Tier2, EventData.EventType.Standard);
				}
				else if (turnManager.currentTurn >= 40)
				{
					SpawnEvent(EventData.EventTier.Tier3, EventData.EventType.Standard);
				}   
			}
			for (int i = 0; i < chain; i++) 
			{
				if (turnManager.currentTurn >= 0 && turnManager.currentTurn < 20)
				{
					SpawnEvent(EventData.EventTier.Tier1, EventData.EventType.Standard);
				}
				else if (turnManager.currentTurn >= 20 && turnManager.currentTurn < 40)
				{
					SpawnEvent(EventData.EventTier.Tier2, EventData.EventType.Standard);
				}
				else if (turnManager.currentTurn >= 40)
				{
					SpawnEvent(EventData.EventTier.Tier3, EventData.EventType.Standard);
				}   
			}
			for (int i = 0; i < domino; i++) 
			{
				if (turnManager.currentTurn >= 0 && turnManager.currentTurn < 20)
				{
					SpawnEvent(EventData.EventTier.Tier1, EventData.EventType.Standard);
				}
				else if (turnManager.currentTurn >= 20 && turnManager.currentTurn < 40)
				{
					SpawnEvent(EventData.EventTier.Tier2, EventData.EventType.Standard);
				}
				else if (turnManager.currentTurn >= 40)
				{
					SpawnEvent(EventData.EventTier.Tier3, EventData.EventType.Standard);
				}   
			}
		}*/
    }
    public EventPopUpBase GetSelectedEvent()
    {
            return selectedEvent;
    }
		
}