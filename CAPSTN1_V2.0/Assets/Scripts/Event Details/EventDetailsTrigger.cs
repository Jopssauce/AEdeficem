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
        FindObjectOfType<EventDetailsManager>().ShowEventDescription(EventDetail, ResourceManager.ResourceType.Water);
    }

    public void ResovleButtonClicked()
    {
        Debug.Log("Resolved");
    }

    public void IgnoreButtonClicked()
    {
        Debug.Log("Ignored");
    }
}
