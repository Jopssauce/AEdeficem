using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EventDetails 
{
	public string EventName;
    [TextArea(3, 999)]
	public string Details;

}