using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DominoEventPanel : EventPanel 
{
	public Button resolveChoice1;
	public Button resolveChoice2;
	public Button uniqueChoice3;	

	public void StandardChoice()
	{
		eventOrigin.GetComponent<DominoEvent> ().StandardChoice ();
	}
	public void DominoChoice()
	{
		eventOrigin.GetComponent<DominoEvent> ().DominoChoice ();
	}
}
