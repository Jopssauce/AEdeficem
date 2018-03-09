using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoEvent : EventPopUpBase 
{
	public bool firstChoice;
	public bool secondChoice;


	public override void Start ()
	{
		base.Start ();
		firstChoice 	= false;
		secondChoice 	= false;
	}
	public void StandardChoice()
	{
		base.ResolveEvent ();
	}
	public void DominoChoice()
	{
		base.ResolveEvent ();
	}	
	public override void AssignButtons ()
	{
		if (firstChoice == true)
		{
			eventPanel.GetComponent<DominoEventPanel>().resolveChoice1.interactable = false;
			eventPanel.GetComponent<DominoEventPanel>().resolveChoice2.interactable = true;
		}
		if (secondChoice == true)
		{
			eventPanel.GetComponent<DominoEventPanel>().resolveChoice1.interactable = true;
			eventPanel.GetComponent<DominoEventPanel>().resolveChoice2.interactable = false;
		}
	}
}
