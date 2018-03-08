﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChainEvent : EventPopUpBase 
{
	public List<GameObject> persistentEvents;
	public GameObject 		persistentEventPrefab;
	public bool longTerm;
	public bool shortTerm;
	public override void Start ()
	{
		base.Start ();
		longTerm = false;
		shortTerm = false;
	}
	void OnClick()
	{
		eventManager.selectedEvent = this.GetComponent<EventPopUpBase>();
		eventPanel = Instantiate (eventPanelPrefab);
	}

	public override void ResolveEvent ()
	{
		if (GetComponent<EventPopUpBase>().isResolved == true)
        {
            Debug.Log("Refund");
            resManager.AddResource(ResourceManager.ResourceType.ActionPoints,eventData.actionCost);
            resManager.AddResource(ResourceManager.ResourceType.Water,  eventData.waterCost);
            resManager.AddResource(ResourceManager.ResourceType.Power, 	eventData.powerCost);
            resManager.AddResource(ResourceManager.ResourceType.Food,   eventData.foodCost);
        }
		if (ResourceManager.instance.isEnoughRes(this.gameObject) == true)
        {
			resManager.DeductResource(ResourceManager.ResourceType.ActionPoints, eventData.actionCost);
			resManager.DeductResource(ResourceManager.ResourceType.Water,	eventData.waterCost);
			resManager.DeductResource(ResourceManager.ResourceType.Power, eventData.powerCost);
			resManager.DeductResource(ResourceManager.ResourceType.Food, eventData.foodCost);
			Destroy(eventPanel);
        }
        else
        {
            Debug.Log("Not Enough Resources");
        }
		isResolved = true;
		shortTerm = true;
		longTerm = false;
		this.GetComponent<Button>().interactable = true;
	}

	public void LongTermResolve()
	{
		if (GetComponent<EventPopUpBase>().isResolved == true)
        {
            Debug.Log("Refund");
            resManager.AddResource(ResourceManager.ResourceType.ActionPoints,eventData.actionCost);
            resManager.AddResource(ResourceManager.ResourceType.Water,  eventData.waterCost);
            resManager.AddResource(ResourceManager.ResourceType.Power, 	eventData.powerCost);
            resManager.AddResource(ResourceManager.ResourceType.Food,   eventData.foodCost);
        }
		if (ResourceManager.instance.isEnoughRes(this.gameObject) == true)
        {
			resManager.DeductResource(ResourceManager.ResourceType.ActionPoints, eventData.actionCost);
			resManager.DeductResource(ResourceManager.ResourceType.Water,	eventData.waterCost);
			resManager.DeductResource(ResourceManager.ResourceType.Power, eventData.powerCost);
			resManager.DeductResource(ResourceManager.ResourceType.Food, eventData.foodCost);
			Destroy(eventPanel);
        }
        else
        {
            Debug.Log("Not Enough Resources");
        }
		isResolved = true;
		longTerm = true;
		shortTerm = false;
		eventManager.isChainEvent = true;
		this.GetComponent<Button>().interactable = true;
	}

	public override void IgnoreEvent ()
	{
		base.IgnoreEvent ();
	}

	public override void AssignButtons ()
	{
		eventPanel.GetComponent<EventReader>().ignoreButton.GetComponent<ResolveButton>().eventOrigin      = this.GetComponent<ChainEvent>();
		eventPanel.GetComponent<EventReader>().resolveButton.GetComponent<LongResolveButton>().eventOrigin    = this.GetComponent<ChainEvent>();
		if (longTerm == true)
        {
            eventPanel.GetComponent<EventReader>().resolveButton.GetComponent<Button>().interactable = false;
            eventPanel.GetComponent<EventReader>().ignoreButton.GetComponent<Button>().interactable = true;
        }
        if (shortTerm == true)
        {
            eventPanel.GetComponent<EventReader>().resolveButton.GetComponent<Button>().interactable = true;
            eventPanel.GetComponent<EventReader>().ignoreButton.GetComponent<Button>().interactable = false;
        }
	}
	
	public void SpawnChildEvents(int amount)
	{
		for (int i = 0; i < amount; i++) 
		{
			if (persistentEvents.Count != 3) 
			{
				GameObject newEvent = Instantiate(persistentEventPrefab);
				newEvent.GetComponent<ChainChildEvent>().regionOrigin = this.regionOrigin;
				newEvent.GetComponent<ChainChildEvent>().eventOrigin = this.GetComponent<ChainEvent>();
				newEvent.transform.SetParent(Canvas.FindObjectOfType<Canvas>().transform);
				newEvent.GetComponent<ChainChildEvent>().eventData    = eventManager.eventsList.tier1Events[Random.Range(0, eventManager.eventsList.tier1Events.Count)];
				persistentEvents.Add (newEvent);
			}

		}
	}
	
	public override void UpdateEvent()
	{           
			if (isResolved == true && longTerm == true)
			{
				longTerm = false;
				regionOrigin.GetComponent<RegionBase>().regionQuality += eventData.qualityDecay * regionOrigin.GetComponent<RegionBase>().maxRegionQuality;
				turnsLeft = 0;
				GetComponent<Button> ().interactable = false;
				SpawnChildEvents (3);

			}
			if (isResolved == true && shortTerm == true)
			{
				regionOrigin.GetComponent<RegionBase>().regionQuality += eventData.qualityDecay * regionOrigin.GetComponent<RegionBase>().maxRegionQuality;
				turnsLeft = 0;
				Destroy(this.gameObject);

				eventManager.eventTracker.Remove(this.gameObject);
			}
			if (isResolved == false )
			{
				turnsLeft -= 1;

				if (turnsLeft > 0)
				{
					GetComponent<Image>().sprite = timerSprites[turnsLeft - 1];	
				}
				if (turnsLeft <= 0)
				{
					Destroy(this.gameObject);
					eventManager.eventTracker.Remove(this.gameObject);
				}
		
			}
			if (persistentEvents.Count <= 0 && isResolved == true)
			{
				Destroy(this.gameObject);

				eventManager.eventTracker.Remove(this.gameObject);
			}
	}

}
