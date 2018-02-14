using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayResourceCost : MonoBehaviour {
	public GameObject eventOrigin;
	public Text waterCost;
	public Text powerCost;
	public Text foodCost;
	public Text actionCost;
	
	// Update is called once per frame
	void Update () 
	{
		if (eventOrigin != null)
		{
			waterCost.text = eventOrigin.GetComponent<EventPopUpBase>().eventData.waterCost.ToString();
			powerCost.text = eventOrigin.GetComponent<EventPopUpBase>().eventData.powerCost.ToString();
			foodCost.text = eventOrigin.GetComponent<EventPopUpBase>().eventData.foodCost.ToString();
			actionCost.text = eventOrigin.GetComponent<EventPopUpBase>().eventData.actionCost.ToString();
		}
	}
}
