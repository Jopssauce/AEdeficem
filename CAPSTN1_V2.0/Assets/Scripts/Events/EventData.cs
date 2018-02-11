using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EventData
{
	public string  	eventName;
	public int 		turnsLeft = 3;
	public bool		isResolved;
	public Sprite 	eventSprite;

	[Header("Resource Costs")]
	public int 		waterCost;
	public int 		foodCost;
	public int 		powerCost;
	public int 		actionCost;
	[TextArea(3,10)]
    public string 	eventDetails;

	ResourceManager.ResourceType resourceType;
}
