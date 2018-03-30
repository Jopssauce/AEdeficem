
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
	public Text currentResearchDetails;

	public List<Sprite> TierIcons;

	public ResearchManager researchManager;
	public TurnManager turnManager;

	public NotificationPanel notificationPanel;

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

	void OnEnable()
	{
		//SetButtonInteractable();
	}
	public void SelectResearch(ResearchButton button)
	{
	
		switch (button.type)
		{
			case Technology.TechType.Disaster:
			researchManager.selectedResearch = researchManager.disasterPrepTechCopy[button.tierNum - 1];
			
			break;
			case Technology.TechType.Resource:
			researchManager.selectedResearch = researchManager.resourceProdTechCopy[button.tierNum - 1];

			break;
			case Technology.TechType.Transport:
			researchManager.selectedResearch = researchManager.transportEffTechCopy[button.tierNum - 1];

			break;
			case Technology.TechType.Regional:
			researchManager.selectedResearch = researchManager.regionalPlanTechCopy[button.tierNum - 1];
			
			break;
			default:
			break;
		}

		if (researchManager.selectedResearch != null)
		{
			researchManager.selectedResearch.isResearching = !researchManager.selectedResearch.isResearching;
		}
		
		researchManager.selectedButton = button;
		SetButtonInteractable();
	}

	public void DeselectResearch()
	{
		researchManager.selectedResearch.isResearching = !researchManager.selectedResearch.isResearching;
		researchManager.selectedResearch = null;
	}

	public void SetButtonInteractable()
	{
		foreach (var item in disasterPrepButtons)
		{
			if (item.GetComponent<ResearchButton>().tierNum != researchManager.tierProgress.disasterPrepTier + 1)
			{
				item.interactable = false;
				
				if (researchManager.tierProgress.disasterPrepTier + 1 > item.GetComponent<ResearchButton> ().tierNum)
				{
					item.GetComponent<ResearchButton> ().GetComponent<Image> ().sprite = TierIcons [item.GetComponent<ResearchButton> ().tierNum - 1];
				}
			}
			
			if (item.GetComponent<ResearchButton>().tierNum == researchManager.tierProgress.disasterPrepTier + 1)
			{
				item.interactable = true;
			}
			if (researchManager.selectedResearch != null && researchManager.selectedResearch.type != Technology.TechType.Disaster)
			{
					item.interactable = false;
			}
		}

		foreach (var item in resourceProdButtons)
		{
			if (item.GetComponent<ResearchButton>().tierNum != researchManager.tierProgress.resourceProdTier + 1)
			{
				item.interactable = false;
				if (researchManager.tierProgress.resourceProdTier + 1 > item.GetComponent<ResearchButton> ().tierNum)
				{
					item.GetComponent<ResearchButton> ().GetComponent<Image> ().sprite = TierIcons [item.GetComponent<ResearchButton> ().tierNum - 1];
				}
			}
			else
			{
				item.interactable = true;
			}
			if (researchManager.selectedResearch != null && researchManager.selectedResearch.type != Technology.TechType.Resource)
			{
					item.interactable = false;
			}
		}

		foreach (var item in regionalPlanButtons)
		{
			if (item.GetComponent<ResearchButton>().tierNum != researchManager.tierProgress.regionalPlanTier + 1)
			{
				item.interactable = false;
				if (researchManager.tierProgress.regionalPlanTier + 1 > item.GetComponent<ResearchButton> ().tierNum)
				{
					item.GetComponent<ResearchButton> ().GetComponent<Image> ().sprite = TierIcons [item.GetComponent<ResearchButton> ().tierNum - 1];
				}
			}
			else
			{
				item.interactable = true;
			}
			if (researchManager.selectedResearch != null && researchManager.selectedResearch.type != Technology.TechType.Regional)
			{
					item.interactable = false;
			}
		}
		foreach (var item in transportEffButtons)
		{
			if (item.GetComponent<ResearchButton>().tierNum != researchManager.tierProgress.transportEffTier + 1)
			{
				item.interactable = false;
				if (researchManager.tierProgress.transportEffTier + 1 > item.GetComponent<ResearchButton> ().tierNum)
				{
					item.GetComponent<ResearchButton> ().GetComponent<Image> ().sprite = TierIcons [item.GetComponent<ResearchButton> ().tierNum - 1];
				}
			}
			else
			{
				item.interactable = true;
			}
			if (researchManager.selectedResearch != null && researchManager.selectedResearch.type != Technology.TechType.Transport)
			{
					item.interactable = false;
			}
		}
	}

	public void SetSelectedResearchText()
	{
		if (researchManager.selectedResearch != null)
		{
			currentResearch.text = researchManager.selectedResearch.techName;
			currentResearchTurns.text =  "Status: " + researchManager.selectedResearch.turnsLeft + " Turns left";
			currentResearchDetails.text = researchManager.selectedResearch.techDescription;
		}
		if (researchManager.selectedResearch == null)
		{
			currentResearch.text = "";
			currentResearchTurns.text =  "";
			currentResearchDetails.text = "";
		}
	}

	public void exitClick()
	{
		this.gameObject.SetActive(false);
		FindObjectOfType<AudioManager> ().Play ("Generic");
	}

}
