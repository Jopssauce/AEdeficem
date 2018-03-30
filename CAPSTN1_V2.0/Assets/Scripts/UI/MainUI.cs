﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MainUI : MonoBehaviour
{
    public Text WaterAmnt;
    public Text PowerAmnt;
    public Text FoodAmnt;
    public Text APAmnt;

    public Text waterAmntSum;
    public Text powerAmntSum;
    public Text foodAmntSum;
    public Text apAmntSum;

    public Text Turn;

    public Button TurnButton;
    public Button researchButton;
	public Button gameExitButton;

    public UnityEvent EventSelected;
    public UnityEvent EventClosed;

    private ResourceManager resManager;
    private TurnManager 	turnManager;
    private RegionManager   regManager;
    private EventManager    eventManager;
    public TutorialManager  tutorialManager;

    public List<GameObject> regionUnderlayDisplayList;

    public GameObject regionUnderlayDisplay;
    public GameObject regionOutlinerContent;

    public GameObject toggleUnderlayDisplay;
    public GameObject researchPanel;

	public UnityEvent EscButtonPressed;
    
	public bool isEscapeMenu;
    // Use this for initialization
    
    void Start ()
    {
        turnManager = TurnManager.instance;
        resManager  = ResourceManager.instance;
        regManager  = RegionManager.instance;
        eventManager = EventManager.instance;
		isEscapeMenu = false;

        foreach (var region in regManager.regionList)
        {
            GameObject ruBar            = Instantiate(regionUnderlayDisplay);
            //GameObject ruBarOutliner    = Instantiate(regionOutlinerContent);

            ruBar.GetComponent<RegionUnderlayDisplay>().regionOrigin            = region.GetComponent<RegionBase>();
            ruBar.GetComponent<BindToRegion>().regionOrigin 					= region.GetComponent<RegionBase>();
            //ruBarOutliner.GetComponent<RegionUnderlayDisplay>().regionOrigin    = region.GetComponent<RegionBase>();

            regionUnderlayDisplayList.Add(ruBar);
            ruBar.transform.SetParent(this.transform, false);
            //ruBarOutliner.transform.SetParent(regionOutliner.transform, false);
        }
        
        foreach (var underlay in regionUnderlayDisplayList)
        {
        underlay.SetActive(true);
        }
		resManager.AdjustedResourceEvent.AddListener (UpdateUiText);
		eventManager.ResolvedEvent.AddListener (UpdateUiText);
		eventManager.IgnoredEvent.AddListener (UpdateUiText);
        EventSelected.AddListener(DisableButtons);
        EventClosed.AddListener(EnableButtons);
        turnManager.EndTurnEvent.AddListener(UpdateUiText);
    
    }

    public void UpdateUiText()
    {
        WaterAmnt.text 	= resManager.water.ToString();
        PowerAmnt.text 	= resManager.power.ToString();
        FoodAmnt.text 	= resManager.food.ToString();
        APAmnt.text 	= resManager.actionPoints.ToString();

        SumText(waterAmntSum,   resManager.waterSum);
        SumText(powerAmntSum,   resManager.powerSum);
        SumText(foodAmntSum,    resManager.foodSum);
        SumText(apAmntSum,      resManager.actionPointsSum);

        Turn.text = turnManager.currentTurn.ToString();
    }

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			isEscapeMenu = !isEscapeMenu;
			if (isEscapeMenu == true) 
			{
				gameExitButton.gameObject.SetActive (true);
			}
			if (isEscapeMenu == false) 
			{
				gameExitButton.gameObject.SetActive (false);
			}
		}
	}

    void SumText(Text text, int sum)
    {
        if (sum >= 0)
        {
            text.text = "+" + sum.ToString();
        }
        if (sum < 0)
        {
            text.text = "-" + sum.ToString();
        }
    }

    public void DisableButtons()
    {
        TurnButton.interactable = false;
        for(int i = 0; i < eventManager.eventTracker.Count; i++)
        {
            eventManager.eventTracker[i].GetComponent<Button>().interactable = false;
        }
    }

    public void EnableButtons()
    {
        TurnButton.interactable = true;
        for (int i = 0; i < eventManager.eventTracker.Count; i++)
        {
            eventManager.eventTracker[i].GetComponent<Button>().interactable = true;
        }
    }

    public void toggleRegionUnderlayDisplay()
    {
		FindObjectOfType<AudioManager> ().Play ("Generic");
        foreach (var underlay in regionUnderlayDisplayList)
        {
            if (underlay.activeInHierarchy == false)
            {
                underlay.SetActive(true);
            }
            else
            {
                underlay.SetActive(false);
            }
        }
    }

    public void openResearchPanel()
    {
        /*if (tutorialManager != null)
        {
            if (tutorialManager.currentTutorialStepPanel != null)
            {
                if (tutorialManager.currentTutorialStepPanel.GetComponent<ResearchStep>())
                {
                    tutorialManager.currentTutorialStepPanel.GetComponent<ResearchStep>().isStepDone = true;
                    tutorialManager.currentTutorialStepPanel.GetComponent<ResearchStep>().nextButtonClick();
                }
            }           
        }*/
       
        researchPanel.transform.SetParent(this.transform, false);
        researchPanel.transform.SetAsLastSibling();
        researchPanel.SetActive(true);
		FindObjectOfType<AudioManager> ().Play ("Generic");
    }
}