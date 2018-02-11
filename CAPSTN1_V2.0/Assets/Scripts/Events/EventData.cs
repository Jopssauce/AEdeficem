using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EventData
{
	public string  	eventName;
	public int 		turnsLeft;
	public int 		resourceCost;
	public Sprite 	eventSprite;
	[TextArea(3,10)]
    public string 	eventDetails;

	ResourceManager.ResourceType resourceType;
}
