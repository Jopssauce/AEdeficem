using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDetailsManager : MonoBehaviour {

	private string sentences;
    // Use this for initialization
    void Start()
    {

    }

    public void ShowEventDescription(EventDetails Desc, ResourceManager.ResourceType type)
    {
        switch (type)
        {
            case ResourceManager.ResourceType.Food:
                Desc.EventName = "Food Shortage";
                Desc.Details = "There has been a problem with the food supply resolve it as soon as possible";
                break;
        }

        Debug.Log("Event: " + Desc.EventName + "Details: " + Desc.Details);
    }
}
