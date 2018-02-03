﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "EventDetails")]
public class EventDetails : ScriptableObject 
{
	public List<string> EventName;
    public List<int> TurnsBeforeFail;
	[TextArea]
	public List<string> EventDescription;
}
