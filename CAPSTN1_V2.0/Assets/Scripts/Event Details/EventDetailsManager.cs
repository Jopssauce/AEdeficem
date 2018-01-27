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

            case ResourceManager.ResourceType.Power:
                Desc.EventName = "Power Outage";
                Desc.Details = "Power outages our always bad to people especially the people who are depended on it";
                break;

            case ResourceManager.ResourceType.Water:
                Desc.EventName = "Water Shortage";
                Desc.Details = "We all know that we cannot survive without water and is actually our main source of life and it is running out halp";
                break;
        }

        Debug.Log("Event: " + Desc.EventName + "Details: " + Desc.Details);
    }
}
