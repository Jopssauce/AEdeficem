using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Event List", menuName = "EventsList")]
public class EventsList : ScriptableObject 
{
	public List<EventData> tier1Events;
	public List<EventData> tier2Events;
	public List<EventData> tier3Events;
	public List<EventData> tier4Events;

    public List<EventData> chainEvent;
    public List<EventData> globalEvent;

}
