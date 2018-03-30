using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EventPopUpBase : MonoBehaviour, IPointerClickHandler
{
    public EventData   	eventDataCopy;
    public EventData   	eventData;
    public RegionBase  	regionOrigin;
    public int         	turnsLeft;
    public bool        	isResolving;
    public bool         isResolved;
    public Vector3     	eventWorldPos;
    public List<Sprite> timerSprites;
	public Sprite 		ResolvingSprite;
    public CityBase     cityOrign;

    public Text         turnsToResolve;
    
	public GameObject	eventPanel;
	public GameObject	eventPanelPrefab;
	public GameObject 	RightClickPanelPrefab;
	public GameObject 	rightClickPanel { get; set;}
    public UnitBase     unit;

    public ResourceManager 	resManager;
    public EventManager    	eventManager;
	public RegionManager	regionManager;
    public TurnManager      turnManager;
    public TutorialManager  tutorialManager;

    private MainUI disableButtons;

	public virtual void Start ()
    {
        //eventData = Instantiate(eventDataCopy);
        isResolving = false;
        isResolved = false;

        if (ResourceManager.instance != null)
		{
			resManager = ResourceManager.instance;
		}
        if (EventManager.instance != null)
		{
			eventManager = EventManager.instance;
		}
		if (RegionManager.instance != null) 
		{
			regionManager = RegionManager.instance;
		}
        if (TurnManager.instance != null) 
		{
			turnManager = TurnManager.instance;
		}
        this.GetComponent<Button>().onClick.AddListener(Click);
		this.GetComponent<BindToRegion> ().regionOrigin = regionOrigin;
        turnManager.EndTurnEvent.AddListener(UpdateEvent);
        cityOrign = regionOrigin.cityOrigin;
        tutorialManager = cityOrign.tutorialManager;
        if (turnsLeft > 0)
        {
        GetComponent<Image>().sprite = timerSprites[turnsLeft - 1];	
        }
	}
	
    public void Click()
    {   
		eventPanel = Instantiate(eventPanelPrefab) as GameObject;
		eventPanel.transform.SetParent(GameObject.FindGameObjectWithTag("Main UI").transform, false);

		eventManager.selectedEvent = this.GetComponent<EventPopUpBase>();
		eventPanel.GetComponent<EventPanel>().eventOrigin                = this;
		AssignButtons ();
        //eventPanel.GetComponent<EventPanel>().exitButton.GetComponent<ExitButton>().eventOrigin = this.GetComponent<EventPopUpBase>();
		eventPanel.GetComponent<EventPanel>().eventThumbnail.sprite      = eventDataCopy.eventSprite;
		eventPanel.GetComponent<EventTextDisplay>().eventOrigin           = this.gameObject;
		eventPanel.GetComponent<DisplayResourceCost>().eventOrigin        = this.GetComponent<EventPopUpBase>();
        eventPanel.GetComponent<DisplayCityResources>().eventOrigin       = this.GetComponent<EventPopUpBase>();
		eventPanel.SetActive(true);
		eventPanel.transform.SetAsLastSibling();
        this.GetComponent<Button>().interactable = false;
    }

	public virtual void AssignButtons()
	{
        eventPanel.GetComponent<EventReader>().resolveButton.GetComponent<Button>().interactable = false;
        eventPanel.GetComponent<EventReader>().refundButton.GetComponent<Button>().interactable = false;
        eventPanel.GetComponent<EventReader>().resolveButton.gameObject.SetActive(false);
        eventPanel.GetComponent<EventReader>().refundButton.gameObject.SetActive(false);
        if (unit != null)
        {
            eventPanel.GetComponent<EventPanel>().sendUnitButton.interactable = false;
            eventPanel.GetComponent<EventPanel>().sendUnitButton.gameObject.SetActive(false);
            eventPanel.GetComponent<EventReader>().unitIsBeingSent.gameObject.SetActive(true);            
        }
         if (unit == null)
        {
            eventPanel.GetComponent<EventPanel>().sendUnitButton.interactable = true;
            eventPanel.GetComponent<EventPanel>().sendUnitButton.gameObject.SetActive(true);
            eventPanel.GetComponent<EventReader>().unitIsBeingSent.gameObject.SetActive(false);
        }
        if (isResolving == true && unit != null && unit.isArrived == true)
        {
            eventPanel.GetComponent<EventReader>().resolveButton.gameObject.SetActive(true);
            eventPanel.GetComponent<EventReader>().refundButton.gameObject.SetActive(true);
            eventPanel.GetComponent<EventReader>().unitIsBeingSent.gameObject.SetActive(false);
            eventPanel.GetComponent<EventReader>().resolveButton.GetComponent<Button>().interactable = false;
            eventPanel.GetComponent<EventReader>().refundButton.GetComponent<Button>().interactable = true;
        }
        if (isResolving == false && unit != null  && unit.isArrived == true)
        {
            eventPanel.GetComponent<EventReader>().resolveButton.gameObject.SetActive(true);
            eventPanel.GetComponent<EventReader>().refundButton.gameObject.SetActive(true);
            eventPanel.GetComponent<EventReader>().unitIsBeingSent.gameObject.SetActive(false);
            eventPanel.GetComponent<EventReader>().resolveButton.GetComponent<Button>().interactable = true;
            eventPanel.GetComponent<EventReader>().refundButton.GetComponent<Button>().interactable = false;
        }
      
	}

	public void RefundEvent()
    {

        if (GetComponent<EventPopUpBase>().isResolving == true)
        {
            Debug.Log("Refund");
            resManager.AddResource(ResourceManager.ResourceType.ActionPoints,eventDataCopy.actionCost);
            cityOrign.AddCityResource(CityBase.ProductionType.Water,  eventDataCopy.waterCost);
            cityOrign.AddCityResource(CityBase.ProductionType.Power, 	eventDataCopy.powerCost);
            cityOrign.AddCityResource(CityBase.ProductionType.Food,   eventDataCopy.foodCost);
        }

		if (turnsLeft > 0)
		{
			GetComponent<Image>().sprite = timerSprites[turnsLeft - 1];	
		}

       	isResolving = false;
        this.GetComponent<Button>().interactable = true;
		Destroy(eventPanel);
    }

	public virtual void ResolveEvent()
    {
        if (isResolving == false)
        {
            if (isEnoughRes() == true)
            {
                turnsToResolve.gameObject.SetActive(true);
                turnsToResolve.text = eventDataCopy.turnsToResolve.ToString();
                isResolving = true;
                resManager.DeductResource(ResourceManager.ResourceType.ActionPoints, eventDataCopy.actionCost);
                cityOrign.DeductCityResource(CityBase.ProductionType.Water,	eventDataCopy.waterCost);
                cityOrign.DeductCityResource(CityBase.ProductionType.Power, eventDataCopy.powerCost);
                cityOrign.DeductCityResource(CityBase.ProductionType.Food, eventDataCopy.foodCost);
				GetComponent<Image> ().sprite = ResolvingSprite;
                if (tutorialManager != null)
                {
                    if (tutorialManager.currentTutorialStepPanel != null)
                    {
                        if (tutorialManager.currentTutorialStepPanel.GetComponent<SendUnitStep2>())
                        {
                            tutorialManager.currentTutorialStepPanel.GetComponent<SendUnitStep2>().isStepDone = true;
                            tutorialManager.currentTutorialStepPanel.GetComponent<SendUnitStep2>().nextButtonClick();
                        }
                    }           
                }
				Destroy(eventPanel);
            }
            else
            {
                eventPanel.GetComponent<EventReader>().notificationPanel.text.text ="Insufficient Resources";
                eventPanel.GetComponent<EventReader>().notificationPanel.gameObject.SetActive(true);
                Debug.Log("Not Enough Resources");
            }
            this.GetComponent<Button>().interactable = true;
        }
    }
    public virtual void UpdateEvent()
    {
        if (isResolving == true)
        {
            eventDataCopy.turnsToResolve--;
           
            turnsToResolve.text = eventDataCopy.turnsToResolve.ToString();
            if (eventDataCopy.turnsToResolve <= 0)
            {
                isResolved = true;
            }
        }
        if (isResolved == true)
        {
            regionOrigin.GetComponent<RegionBase>().regionQuality += eventDataCopy.qualityDecay *regionOrigin.GetComponent<RegionBase>().maxRegionQuality;
            turnsLeft = 0;
            
            Destroy(this.gameObject);
            eventManager.eventTracker.Remove(this.gameObject);
        }
        if (isResolving == false)
        {
            turnsToResolve.gameObject.SetActive(false);
            turnsLeft -= 1;

            if (turnsLeft > 0)
            {
            GetComponent<Image>().sprite = timerSprites[turnsLeft - 1];	
            }
            if (turnsLeft <= 0)
            {
                Destroy(this.gameObject);
                eventManager.eventTracker.Remove(this.gameObject);
            }
        }
    
    }
    public bool isEnoughRes()
	{
        CityBase cityOrigin = regionOrigin.cityOrigin;
		if (cityOrigin.cityResources.Water < eventDataCopy.waterCost || cityOrigin.cityResources.Food < eventDataCopy.foodCost 
		 || cityOrigin.cityResources.Power < eventDataCopy.powerCost || resManager.actionPoints < eventDataCopy.actionCost)
		{
			return false;
		}
		else
		{
			return true;
		}
		
	}
    public virtual void SpawnUnit()
    {
        
        if (resManager.actionPoints > 0)
        {
            cityOrign.SpawnUnit(this);
            eventManager.SentUnitEvent.Invoke ();
            resManager.DeductResource(ResourceManager.ResourceType.ActionPoints, 1);
            this.GetComponent<Button>().interactable = true;
            Destroy(eventPanel); 
        }
        else
        {
            eventPanel.GetComponent<EventReader>().notificationPanel.text.text ="Insufficient Resources";
            eventPanel.GetComponent<EventReader>().notificationPanel.gameObject.SetActive(true);
            Debug.Log("Not Enough Resources");
        }         
    }

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			/* rightClickPanel = Instantiate (RightClickPanelPrefab);
			rightClickPanel.transform.SetParent(GameObject.FindGameObjectWithTag("Main UI").transform, false);
			rightClickPanel.transform.SetAsLastSibling();
			rightClickPanel.transform.position = this.transform.position + new Vector3 (50.0f, 50.0f, 0.0f);*/
		}
	}
	/*
	void Update()
	{
		if (rightClickPanel != null) 
		{
			rightClickPanel.transform.position = this.transform.position + new Vector3 (50.0f, 50.0f, 0.0f);
		}
	}
	*/
}