using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDetailsManager : MonoBehaviour {

	private string sentences;
    // Use this for initialization
    void Start()
    {
       
    }

    public void ShowEventDescription(EventDetails Desc)
    {
        Debug.Log("Event Message Shown " + Desc.Details);
    }
}
