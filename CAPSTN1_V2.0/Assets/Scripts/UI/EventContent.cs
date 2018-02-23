using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventContent : MonoBehaviour {
	public GameObject 	eventOrigin;
	public GameObject	moveCameraButton;
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
			moveCameraButton.GetComponent<MoveCameraToEvent>().eventWorldPos.x = eventOrigin.GetComponent<EventPopUpBase>().eventWorldPos.x;
			moveCameraButton.GetComponent<MoveCameraToEvent>().eventWorldPos.y = Camera.main.transform.position.y;
			moveCameraButton.GetComponent<MoveCameraToEvent>().eventWorldPos.z = eventOrigin.GetComponent<EventPopUpBase>().eventWorldPos.z - 3f;
		}

		if (turnsLeft <= 0)
		{
			Destroy(this.gameObject);
		}
	}
	
}
