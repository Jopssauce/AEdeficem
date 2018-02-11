using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EventData
{
	public string  	eventName;
	public int 		turnsLeft;
	public Sprite 	eventSprite;

	[Header("Resource Costs")]
	public int 		waterCost;
	public int 		foodCost;
	public int 		powerCost;
	public int 		actionCost;
	[TextArea(3,10)]
    public string 	eventDetails;
	[SerializeField][Range(0.1f, 1.0f)]
    public float qualityDecay;
	[SerializeField][Range(0.1f, 1.0f)]
    public float qualityReward;
	ResourceManager.ResourceType resourceType;
}
