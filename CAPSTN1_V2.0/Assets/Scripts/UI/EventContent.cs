using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventContent : MonoBehaviour {
	public GameObject 	eventOrigin;
	public Vector3 		eventPos;
	public Text 		eventTitle;
	public int 			turnsLeft;
	// Use this for initialization
	void Start () 
	{
		eventTitle.text = eventOrigin.GetComponent<EventPopUpBase>().eventData.eventName;
		this.GetComponent<DisplayResourceCost>().eventOrigin = this.eventOrigin;
	}
	void Update()
	{
		if (eventOrigin != null)
		{
			turnsLeft = eventOrigin.GetComponent<EventPopUpBase>().turnsLeft;
		}

		if (turnsLeft <= 0)
		{
			Destroy(this.gameObject);
		}
	}
	
}
