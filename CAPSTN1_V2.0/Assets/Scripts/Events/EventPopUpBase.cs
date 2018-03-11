using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EventPopUpBase : MonoBehaviour
{
    public EventData   	eventData;
    public RegionBase  	regionOrigin;
    public int         	turnsLeft;
    public bool        	isResolved;
    public Vector3     	eventWorldPos;
    public List<Sprite> timerSprites;
    public CityBase     cityOrign;

	public GameObject	eventPanel;
	public GameObject	eventPanelPrefab;
    public UnitBase     unit;

    public ResourceManager 	resManager;
    public EventManager    	eventManager;
	public RegionManager	regionManager;
    public TurnManager      turnManager;

	public GameObject BlockerPanel;
	public GameObject blockerPanel { get; set;}

    private MainUI disableButtons;

	public virtual void Start ()
    {

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
		eventManager.SentUnitEvent.AddListener (DestroyPanel);
		eventManager.ResolvedEvent.AddListener (DestroyPanel);
		eventManager.IgnoredEvent.AddListener (DestroyPanel);
        cityOrign = regionOrigin.cityOrigin;
	}
	
    public void Click()
    {   
		blockerPanel = Instantiate (BlockerPanel) as GameObject;
		blockerPanel.transform.SetParent(GameObject.FindGameObjectWithTag("Main UI").transform, false);
		eventPanel = Instantiate(eventPanelPrefab) as GameObject;
		eventPanel.transform.SetParent(GameObject.FindGameObjectWithTag("Main UI").transform, false);

		eventManager.selectedEvent = this.GetComponent<EventPopUpBase>();
		eventPanel.GetComponent<EventPanel>().eventOrigin                = this;
		AssignButtons ();
        eventPanel.GetComponent<EventPanel>().exitButton.GetComponent<ExitButton>().eventOrigin = this.GetComponent<EventPopUpBase>();
		eventPanel.GetComponent<EventPanel>().eventThumbnail.sprite      = eventData.eventSprite;
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
        if (isResolved == true && unit != null && unit.isArrived == true)
        {
            eventPanel.GetComponent<EventReader>().resolveButton.GetComponent<Button>().interactable = false;
            eventPanel.GetComponent<EventReader>().refundButton.GetComponent<Button>().interactable = true;
        }
        if (isResolved == false && unit != null  && unit.isArrived == true)
        {
            eventPanel.GetComponent<EventReader>().resolveButton.GetComponent<Button>().interactable = true;
            eventPanel.GetComponent<EventReader>().refundButton.GetComponent<Button>().interactable = false;
        }
        if (unit != null)
        {
            eventPanel.GetComponent<EventPanel>().sendUnitButton.interactable = false;
        }
         if (unit == null)
        {
            eventPanel.GetComponent<EventPanel>().sendUnitButton.interactable = true;
        }
	}

	public void RefundEvent()
    {

        if (GetComponent<EventPopUpBase>().isResolved == true)
        {
            Debug.Log("Refund");
            resManager.AddResource(ResourceManager.ResourceType.ActionPoints,eventData.actionCost);
            cityOrign.AddCityResource(CityBase.ProductionType.Water,  eventData.waterCost);
            cityOrign.AddCityResource(CityBase.ProductionType.Power, 	eventData.powerCost);
            cityOrign.AddCityResource(CityBase.ProductionType.Food,   eventData.foodCost);
        }

       	isResolved = false;
        this.GetComponent<Button>().interactable = true;
		Destroy(eventPanel);
    }

	public virtual void ResolveEvent()
    {
        if (isResolved == false)
        {
            if (ResourceManager.instance.isEnoughRes(this.gameObject) == true)
            {
                isResolved = true;
                resManager.DeductResource(ResourceManager.ResourceType.ActionPoints, eventData.actionCost);
                cityOrign.AddCityResource(CityBase.ProductionType.Water,	eventData.waterCost);
                cityOrign.AddCityResource(CityBase.ProductionType.Power, eventData.powerCost);
                cityOrign.AddCityResource(CityBase.ProductionType.Food, eventData.foodCost);

				Destroy(eventPanel);
            }
            else
            {
                Debug.Log("Not Enough Resources");
            }
            this.GetComponent<Button>().interactable = true;
        }
    }
    public virtual void ExitEvent()
    {
        Destroy(eventPanel);
		DestroyPanel ();
        this.GetComponent<Button>().interactable = true;
    }
    public virtual void UpdateEvent()
    {
        if (isResolved == true)
        {
            regionOrigin.GetComponent<RegionBase>().regionQuality += eventData.qualityDecay *regionOrigin.GetComponent<RegionBase>().maxRegionQuality;
            turnsLeft = 0;
            
            Destroy(this.gameObject);
            eventManager.eventTracker.Remove(this.gameObject);
        }
        if (isResolved == false)
        {
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
    public bool isEnoughRes(GameObject Event)
	{
        CityBase cityOrigin = regionOrigin.cityOrigin;
		if (cityOrigin.cityResources.Water < Event.GetComponent<EventPopUpBase>().eventData.waterCost || cityOrigin.cityResources.Food < Event.GetComponent<EventPopUpBase>().eventData.foodCost 
		 || cityOrigin.cityResources.Power < Event.GetComponent<EventPopUpBase>().eventData.powerCost || resManager.actionPoints < Event.GetComponent<EventPopUpBase>().eventData.actionCost)
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
        cityOrign.SpawnUnit(this);
        resManager.DeductResource(ResourceManager.ResourceType.ActionPoints, 1);
        this.GetComponent<Button>().interactable = true;
        Destroy(eventPanel);   
    }

	public void DestroyPanel()
	{
		Destroy (blockerPanel);
	}
    
}