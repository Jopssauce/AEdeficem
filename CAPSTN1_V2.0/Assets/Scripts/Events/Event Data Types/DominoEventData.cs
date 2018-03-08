using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Event Type", menuName = "Event Type/Domino Event")]
[System.Serializable]
public class DominoEventData : EventData 
{
	public List<string> choicesText;
}
