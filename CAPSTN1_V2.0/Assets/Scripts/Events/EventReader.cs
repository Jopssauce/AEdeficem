﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventReader : MonoBehaviour
{
    public Button EventOrigin;

    public Text EventText;
    public Text EventTitle;

    public Button Unresolve;
    public Button Resolve;

	Queue<string> details;

    // Use this for initialization
    void Start()
    {
		details = new Queue<string> ();
        Unresolve.onClick.AddListener(IgnoreEvent);
        Resolve.onClick.AddListener(ResolveEvent);
    }

    public void ResolveEvent()
    {
        EventOrigin.GetComponent<EventPopUpBase>().isResolved = true;
        Debug.Log(EventOrigin.GetComponent<EventPopUpBase>().isResolved);
        Destroy(this.gameObject);
    }

    public void IgnoreEvent()
    {
        EventOrigin.GetComponent<EventPopUpBase>().isResolved = false;
        //Debug.Log(EventOrigin.GetComponent<EventPopUpBase>().isResolved);
        Destroy(this.gameObject);
    }

	public void StartText()
	{
		
	}
}