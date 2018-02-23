using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIActionElement : MonoBehaviour
{

    public GameObject eventOrigin;
    public Button CloseButton;

    public void RemoveAction()
	{
		if (eventOrigin.GetComponent<EventPopUpBase>().isResolved == true)
		{
			Debug.Log("Refund");
			ResourceManager.instance.AddResource(ResourceManager.ResourceType.ActionPoints, eventOrigin.GetComponent<EventPopUpBase>().eventData.actionCost);
			ResourceManager.instance.AddResource(ResourceManager.ResourceType.Water,	eventOrigin.GetComponent<EventPopUpBase>().eventData.waterCost);
			ResourceManager.instance.AddResource(ResourceManager.ResourceType.Power, 	eventOrigin.GetComponent<EventPopUpBase>().eventData.powerCost);
			ResourceManager.instance.AddResource(ResourceManager.ResourceType.Food, 	eventOrigin.GetComponent<EventPopUpBase>().eventData.foodCost);
		}

        eventOrigin.GetComponent<EventPopUpBase>().isResolved = false;
		Destroy (this.gameObject);
	}

    public void RemoveOnEndTurn()
    {
        this.gameObject.SetActive(false);
        //destroy
    }
}
