using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchButton : MonoBehaviour 
{
	public int tierNum;
	public ResearchPanel 		researchPanel;
	public Technology.TechType  type;
	public Technology 			technology;

	public Sprite selectedResearchIcon;
	public Sprite unSelectedResearchIcon;

	public bool isSelected;
	
	ResourceManager resourceManager;
	public TurnManager turnManager;

	void Start()
	{
		if (ResourceManager.instance != null)
		{
			resourceManager = ResourceManager.instance;
		}
		if (TurnManager.instance != null)
		{
			turnManager = TurnManager.instance;
		}
	}


	public void Select()
	{

		isSelected = !isSelected;
		if (isSelected == true)
		{
			if (resourceManager.actionPoints >= 10)
			{
				researchPanel.SelectResearch(this);
				GetComponent<Image> ().sprite = selectedResearchIcon;
				resourceManager.DeductResource(ResourceManager.ResourceType.ActionPoints,10);
			}
		}
		if (isSelected == false)
		{
			//if (resourceManager.actionPoints <= 0)
			{
				researchPanel.DeselectResearch();
				GetComponent<Image> ().sprite = unSelectedResearchIcon;
				resourceManager.AddResource(ResourceManager.ResourceType.ActionPoints,10);
			}	
		}
		
		
		researchPanel.SetButtonInteractable();
		
	}


}
