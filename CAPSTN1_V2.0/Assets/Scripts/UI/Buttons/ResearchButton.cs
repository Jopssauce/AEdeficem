using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchButton : MonoBehaviour 
{
	public int tierNum;
	public ResearchPanel researchPanel;
	public Technology.TechType type;
	public Sprite selectedResearchIcon;
	public Sprite unSelectedResearchIcon;
	public bool isSelected;
	

	public void Select()
	{
		isSelected = !isSelected;
		if (isSelected == true)
		{
			researchPanel.SelectResearch(this);
			GetComponent<Image> ().sprite = selectedResearchIcon;
		}
		if (isSelected == false)
		{
			researchPanel.researchManager.selectedResearch = null;
			GetComponent<Image> ().sprite = unSelectedResearchIcon;
			
		}
		researchPanel.SetButtonInteractable();
		
	}


}
