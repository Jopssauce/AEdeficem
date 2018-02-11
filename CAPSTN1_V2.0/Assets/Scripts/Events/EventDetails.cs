using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "EventDetails")]
public class EventDetails : ScriptableObject 
{
	public List<EventText> eventText;
	
} 