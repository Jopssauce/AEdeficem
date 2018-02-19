using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventReader : MonoBehaviour
{
    public GameObject ActionQueue;

    public GameObject   eventOrigin;
    public Button       Unresolve;
    public Button       Resolve;

    private GameObject  NewQueueItem;
    public ResourceManager resManager;
    // Use this for initialization
    void Start()
    {
        Unresolve.onClick.AddListener(IgnoreEvent);
        Resolve.onClick.AddListener(ResolveEvent);
        if (ResourceManager.instance != null)
		{
			resManager = ResourceManager.instance;
		}
    }

    public void ResolveEvent()
    {
        if (ResourceManager.instance.isEnoughRes(eventOrigin) == true)
        {
            eventOrigin.GetComponent<EventPopUpBase>().isResolved = true;
            Debug.Log(eventOrigin.GetComponent<EventPopUpBase>().isResolved);

			NewQueueItem = Instantiate(ActionQueue, new Vector3(0.0f, 386.1f + 60.3f), Quaternion.identity) as GameObject;
            NewQueueItem.transform.SetParent(EventManager.instance.newCanvas.transform, false);
            NewQueueItem.GetComponent<AQscript>().eventOrigin = this.eventOrigin;

            resManager.DeductResource(ResourceManager.ResourceType.ActionPoints, eventOrigin.GetComponent<EventPopUpBase>().eventData.actionCost);
            resManager.DeductResource(ResourceManager.ResourceType.Water,	eventOrigin.GetComponent<EventPopUpBase>().eventData.waterCost);
            resManager.DeductResource(ResourceManager.ResourceType.Power, 	eventOrigin.GetComponent<EventPopUpBase>().eventData.powerCost);
            resManager.DeductResource(ResourceManager.ResourceType.Food, 	eventOrigin.GetComponent<EventPopUpBase>().eventData.foodCost);

            EventManager.instance.EventPanel.SetActive(false);
        }
        else
        {
            Debug.Log("Not Enough Resources");
        }
    }

    public void IgnoreEvent()
    {

        if (eventOrigin.GetComponent<EventPopUpBase>().isResolved == true)
        {
            Debug.Log("Refund");
            resManager.AddResource(ResourceManager.ResourceType.ActionPoints, eventOrigin.GetComponent<EventPopUpBase>().eventData.actionCost);
            resManager.AddResource(ResourceManager.ResourceType.Water,	eventOrigin.GetComponent<EventPopUpBase>().eventData.waterCost);
            resManager.AddResource(ResourceManager.ResourceType.Power, 	eventOrigin.GetComponent<EventPopUpBase>().eventData.powerCost);
            resManager.AddResource(ResourceManager.ResourceType.Food, 	eventOrigin.GetComponent<EventPopUpBase>().eventData.foodCost);
        }

        eventOrigin.GetComponent<EventPopUpBase>().isResolved = false;
        EventManager.instance.EventPanel.SetActive(false);
    }


}