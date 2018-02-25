using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EventPopUpBase : MonoBehaviour
{
    public EventData   eventData;
    public GameObject  regionOrigin;
    public int         turnsLeft;
    public bool        isResolved;
    public Vector3     eventWorldPos;
    public List<Sprite> timerSprites;

    public UnityEvent ResolvedEvent;
    public UnityEvent IgnoredEvent;

    ResourceManager resManager;

	void Start ()
    {

        isResolved = false;

        if (ResourceManager.instance != null)
		{
			resManager = ResourceManager.instance;
		}
        this.GetComponent<Button>().onClick.AddListener(Click);
		this.GetComponent<BindToRegion> ().regionOrigin = regionOrigin;

        this.GetComponent<Image>().sprite = timerSprites[turnsLeft - 1];
        IgnoredEvent.AddListener(IgnoreEvent);
        ResolvedEvent.AddListener(ResolveEvent);
	}
	
    void Click()
    {   
        EventManager.instance.EventPanel.GetComponent<EventReader>().eventOrigin                = this.gameObject;
        EventManager.instance.EventPanel.GetComponent<EventReader>().ignoreButton.GetComponent<IgnoreButton>().eventOrigin      = this.GetComponent<EventPopUpBase>();
        EventManager.instance.EventPanel.GetComponent<EventReader>().resolveButton.GetComponent<ResolveButton>().eventOrigin    = this.GetComponent<EventPopUpBase>();
        EventManager.instance.EventPanel.GetComponent<EventReader>().eventThumbnail.sprite      = eventData.eventSprite;
        EventManager.instance.EventPanel.GetComponent<EventTextDisplay>().eventOrigin           = this.gameObject;
        EventManager.instance.EventPanel.GetComponent<DisplayResourceCost>().eventOrigin        = this.gameObject;
        EventManager.instance.EventPanel.SetActive(true);
        EventManager.instance.EventPanel.transform.SetAsLastSibling();
    }

    public void IgnoreEvent()
    {

        if (GetComponent<EventPopUpBase>().isResolved == true)
        {
            Debug.Log("Refund");
            resManager.AddResource(ResourceManager.ResourceType.ActionPoints,eventData.actionCost);
            resManager.AddResource(ResourceManager.ResourceType.Water,  eventData.waterCost);
            resManager.AddResource(ResourceManager.ResourceType.Power, 	eventData.powerCost);
            resManager.AddResource(ResourceManager.ResourceType.Food,   eventData.foodCost);
        }

        //GetComponent<EventPopUpBase>().isResolved = false;
        EventManager.instance.EventPanel.SetActive(false);
    }

    public void ResolveEvent()
    {
        if (isResolved == false)
        {
            if (ResourceManager.instance.isEnoughRes(this.gameObject) == true)
            {
                //GetComponent<EventPopUpBase>().isResolved = true;
                resManager.DeductResource(ResourceManager.ResourceType.ActionPoints, eventData.actionCost);
                resManager.DeductResource(ResourceManager.ResourceType.Water,	eventData.waterCost);
                resManager.DeductResource(ResourceManager.ResourceType.Power, eventData.powerCost);
                resManager.DeductResource(ResourceManager.ResourceType.Food, eventData.foodCost);

                EventManager.instance.EventPanel.SetActive(false);
            }
            else
            {
                Debug.Log("Not Enough Resources");
            }
        }
    }
}