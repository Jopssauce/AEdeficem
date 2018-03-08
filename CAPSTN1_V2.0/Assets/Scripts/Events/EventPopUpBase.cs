﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EventPopUpBase : MonoBehaviour
{
    public EventData   	eventData;
    public GameObject  	regionOrigin;
    public int         	turnsLeft;
    public bool        	isResolved;
    public Vector3     	eventWorldPos;
    public List<Sprite> timerSprites;

	public GameObject	eventPanel;
	public GameObject	eventPanelPrefab;

    public ResourceManager 	resManager;
    public EventManager    	eventManager;
	public RegionManager	regionManager;

	public virtual void Start ()
    {

        isResolved = false;

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
        this.GetComponent<Button>().onClick.AddListener(Click);
		this.GetComponent<BindToRegion> ().regionOrigin = regionOrigin;
        this.GetComponent<Image>().sprite = timerSprites[turnsLeft - 1];
	}
	
    void Click()
    {   
		eventPanel = Instantiate(eventPanelPrefab) as GameObject;
		eventPanel.transform.SetParent(GameObject.FindGameObjectWithTag("Main UI").transform, false);

		eventManager.selectedEvent = this.GetComponent<EventPopUpBase>();
		eventPanel.GetComponent<EventReader>().eventOrigin                = this.gameObject;
		AssignButtons ();
		eventPanel.GetComponent<EventReader>().eventThumbnail.sprite      = eventData.eventSprite;
		eventPanel.GetComponent<EventTextDisplay>().eventOrigin           = this.gameObject;
		eventPanel.GetComponent<DisplayResourceCost>().eventOrigin        = this.gameObject;
		eventPanel.SetActive(true);
		eventPanel.transform.SetAsLastSibling();
		
    }

	public virtual void AssignButtons()
	{
		eventPanel.GetComponent<EventReader>().ignoreButton.GetComponent<IgnoreButton>().eventOrigin      = this.GetComponent<EventPopUpBase>();
		eventPanel.GetComponent<EventReader>().resolveButton.GetComponent<ResolveButton>().eventOrigin    = this.GetComponent<EventPopUpBase>();
        if (isResolved == true)
        {
            eventPanel.GetComponent<EventReader>().resolveButton.GetComponent<Button>().interactable = false;
            eventPanel.GetComponent<EventReader>().ignoreButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            eventPanel.GetComponent<EventReader>().resolveButton.GetComponent<Button>().interactable = true;
            eventPanel.GetComponent<EventReader>().ignoreButton.GetComponent<Button>().interactable = false;
        }
	}

	public virtual void IgnoreEvent()
    {

        if (GetComponent<EventPopUpBase>().isResolved == true)
        {
            Debug.Log("Refund");
            resManager.AddResource(ResourceManager.ResourceType.ActionPoints,eventData.actionCost);
            resManager.AddResource(ResourceManager.ResourceType.Water,  eventData.waterCost);
            resManager.AddResource(ResourceManager.ResourceType.Power, 	eventData.powerCost);
            resManager.AddResource(ResourceManager.ResourceType.Food,   eventData.foodCost);
        }

       	isResolved = false;

		Destroy(eventPanel);
    }

    public virtual void ResolveEvent()
    {
        if (isResolved == false)
        {
            if (ResourceManager.instance.isEnoughRes(this.gameObject) == true)
            {
                isResolved = true;
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
        }
    }
}