using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ResearchPanel : MonoBehaviour 
{
	public List<Button> disasterPrepButtons;
	public List<Button> resourceProdButtons;
	public List<Button> transportEffButtons;
	public List<Button> regionalPlanButtons;

	public Text currentResearch;
	public Text currentResearchTurns;
	

	ResearchManager researchManager;
	TurnManager turnManager;

	public class DisasterPrepClick : UnityEvent<int, int>{}

	public void Start()
	{
		if (ResearchManager.instance != null)
		{
			researchManager = ResearchManager.instance;
		}
		if (TurnManager.instance != null)
		{
			turnManager = TurnManager.instance;
		}
		foreach (var item in disasterPrepButtons)
		{
			if (item.GetComponent<ResearchButton>())
			{
				item.GetComponent<ResearchButton>().researchPanel = this;
			}
			
		}
		SetButtonInteractable();
		turnManager.EndTurnEvent.AddListener(SetButtonInteractable);
		researchManager.ResearchFinished.AddListener(SetButtonInteractable);
	}
	void Update()
	{
		SetSelectedResearchText();
	}
	public void SelectResearch(ResearchButton button)
	{
		if (researchManager.selectedResearch == null)
		{
			switch (button.type)
			{
				case Technology.TechType.Disaster:
				researchManager.selectedResearch = researchManager.disasterPrepTechCopy[button.tierNum - 1];
				researchManager.selectedResearch.isResearching = !researchManager.selectedResearch.isResearching;
				turnManager.EndTurnEvent.AddListener(researchManager.selectedResearch.ResearchTech);
				break;
				case Technology.TechType.Resource:
				researchManager.selectedResearch = researchManager.disasterPrepTechCopy[button.tierNum - 1];
				researchManager.selectedResearch.isResearching = !researchManager.selectedResearch.isResearching;
				turnManager.EndTurnEvent.AddListener(researchManager.selectedResearch.ResearchTech);
				break;
				case Technology.TechType.Transport:
				researchManager.selectedResearch = researchManager.disasterPrepTechCopy[button.tierNum - 1];
				researchManager.selectedResearch.isResearching = !researchManager.selectedResearch.isResearching;
				turnManager.EndTurnEvent.AddListener(researchManager.selectedResearch.ResearchTech);
				break;
				case Technology.TechType.Regional:
				researchManager.selectedResearch = researchManager.disasterPrepTechCopy[button.tierNum - 1];
				researchManager.selectedResearch.isResearching = !researchManager.selectedResearch.isResearching;
				turnManager.EndTurnEvent.AddListener(researchManager.selectedResearch.ResearchTech);
				break;
				default:
				break;
			}
		}
		
	}

	public void SetButtonInteractable()
	{
		foreach (var item in disasterPrepButtons)
		{
			if (item.GetComponent<ResearchButton>().tierNum != researchManager.tierProgress.disasterPrepTier + 1)
			{
				item.interactable = false;
			}
			else
			{
				item.interactable = true;
			}
		}
		
	}

	public void SetSelectedResearchText()
	{
		if (researchManager.selectedResearch != null)
		{
			if (researchManager.selectedResearch.isResearching == true)
			{
				currentResearch.text = researchManager.selectedResearch.techName;
				currentResearchTurns.text =  "Status: " + researchManager.selectedResearch.turnsLeft + " Turns left";
			}
		}
	}



}
