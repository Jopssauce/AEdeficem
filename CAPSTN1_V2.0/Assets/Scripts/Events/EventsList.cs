using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Event", menuName = "EventsList")]
public class EventsList : ScriptableObject 
{
	public List<EventData> eventDataList;

}
