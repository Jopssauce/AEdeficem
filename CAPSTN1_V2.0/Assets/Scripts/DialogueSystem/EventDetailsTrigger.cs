using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDetailsTrigger : MonoBehaviour
{
    public EventDetails EventDetail;

    void Start()
    {
        StartEvent();
    }

    public void StartEvent()
    {
        FindObjectOfType<EventDetailsManager>().ShowEventDescription(EventDetail, ResourceManager.ResourceType.Food);
    }
}
