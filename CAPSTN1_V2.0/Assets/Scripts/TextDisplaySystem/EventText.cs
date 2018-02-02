using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EventText  
{
	public string 	eventName;

	[TextArea(3,10)]
	public string 	eventDetails;

}
