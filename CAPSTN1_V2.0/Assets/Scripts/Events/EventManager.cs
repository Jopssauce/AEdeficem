using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{

	public static EventManager instance = null;
    private TurnManager turnManager;
    public GameObject   baseEvent;
	public GameObject	chainEventPrefab;
    public Canvas       newCanvas;
    public GameObject   EventsPanelPrefab;
    public GameObject   EventPanel;
    public EventsList   eventsList;
    
    public GameObject 		eventOutliner;
    public GameObject 		eventOutlinerContent;
	public List<GameObject> eventOutlinerTracker;

    private RegionManager 	RegionManagerInstance;
    public UnityEvent 		ResolvedEvent;
    public UnityEvent 		IgnoredEvent;
    public List<GameObject> eventTracker;

    public EventPopUpBase selectedEvent;

    void Awake()
	{
        newCanvas = Canvas.FindObjectOfType<Canvas>();

		if (instance == null) 
		{
			instance = this;	
		}
		else if (instance != this) 
		{
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}

    void Start()
    {
        //EventPanel = Instantiate(EventsPanelPrefab) as GameObject;
        //EventPanel.transform.SetParent(newCanvas.transform, false);
        //EventPanel.SetActive(false);
        eventOutliner = GameObject.FindGameObjectWithTag("Event Outliner");
        if (TurnManager.instance != null)
        {
            turnManager = TurnManager.instance;
        }
    }

    public void SpawnEvent(EventData.EventTier eventTier)
    {
        RegionManagerInstance = RegionManager.instance;

		int num 			    = Random.Range(0 , RegionManagerInstance.regionList.Count);
		GameObject newButton    = Instantiate(baseEvent);

        newButton.transform.SetParent(newCanvas.transform, false);

		newButton.GetComponent<EventPopUpBase>().regionOrigin = RegionManagerInstance.regionList[num];

        switch (eventTier)
        {
             case EventData.EventTier.Tier1:
            newButton.GetComponent<EventPopUpBase>().eventData    = eventsList.tier1Events[Random.Range(0, eventsList.tier1Events.Count)];
            break;
             case EventData.EventTier.Tier2:
            newButton.GetComponent<EventPopUpBase>().eventData    = eventsList.tier2Events[Random.Range(0, eventsList.tier2Events.Count)];
            break;
             case EventData.EventTier.Tier3:
            newButton.GetComponent<EventPopUpBase>().eventData    = eventsList.tier3Events[Random.Range(0, eventsList.tier3Events.Count)];
            break;
             case EventData.EventTier.Tier4:
            newButton.GetComponent<EventPopUpBase>().eventData    = eventsList.tier4Events[Random.Range(0, eventsList.tier4Events.Count)];
            break;
            default:
            Debug.Log("Error tier list");
            break;
        }

        GameObject newEventContent                                  = Instantiate(eventOutlinerContent);
        newEventContent.GetComponent<EventContent>().eventOrigin    = newButton;
        
        newButton.GetComponent<EventPopUpBase>().turnsLeft          = newButton.GetComponent<EventPopUpBase>().eventData.turnsLeft;
		eventOutlinerTracker.Add(newEventContent);

		newEventContent.transform.SetParent(eventOutliner.transform, false);
        
        eventTracker.Add(newButton);
    }

    private Vector3 RandomPointInPolygon(Vector3 center, Bounds size)
    {
		return center + new Vector3((Random.value - 0.55f) * size.extents.x,(Random.value - 0.55f) * size.extents.y, (Random.value - 0.55f) * size.extents.z);
    }

    public void UpdateEvents()
    {
        if (eventTracker != null)
        {
            foreach (var item in eventTracker.ToArray())
            {
                EventPopUpBase eventPopUp = item.GetComponent<EventPopUpBase>();
                
				if (item.GetComponent<ChainEvent>()) 
				{
					ChainEvent chainEvent = item.GetComponent<ChainEvent> ();
					if (chainEvent.isResolved == true && chainEvent.longTerm == false)
					{
						chainEvent.regionOrigin.GetComponent<RegionBase>().regionQuality += eventPopUp.eventData.qualityDecay * eventPopUp.regionOrigin.GetComponent<RegionBase>().maxRegionQuality;
						chainEvent.turnsLeft = 0;
						chainEvent.GetComponent<Button> ().interactable = false;
						chainEvent.SpawnChildEvents (3);

					}
					if (chainEvent.isResolved == false)
					{
						chainEvent.turnsLeft -= 1;

						if (chainEvent.turnsLeft > 0)
						{
							chainEvent.GetComponent<Image>().sprite = eventPopUp.timerSprites[eventPopUp.turnsLeft - 1];	
						}
						if (chainEvent.turnsLeft <= 0)
						{
							Destroy(item.gameObject);
							eventTracker.Remove(item);
						}
					}

				}

				else if (item.GetComponent<EventPopUpBase>()) 
				{
					if (item.GetComponent<EventPopUpBase> ().isResolved == true)
					{
						eventPopUp.regionOrigin.GetComponent<RegionBase>().regionQuality += eventPopUp.eventData.qualityDecay * eventPopUp.regionOrigin.GetComponent<RegionBase>().maxRegionQuality;
						eventPopUp.turnsLeft = 0;
						Destroy(item.gameObject);

						eventTracker.Remove(item);
					}
					if (eventPopUp.isResolved == false)
					{
						eventPopUp.turnsLeft -= 1;

						if (eventPopUp.turnsLeft > 0)
						{
							eventPopUp.GetComponent<Image>().sprite = eventPopUp.timerSprites[eventPopUp.turnsLeft - 1];	
						}
						if (eventPopUp.turnsLeft <= 0)
						{
							Destroy(item.gameObject);
							eventTracker.Remove(item);
						}
					}
				}
                
                
            }
			for (int i = 0; i < Random.Range(1,3); i++)
            {
                if (eventTracker.Count != 5)
                {
                    if (turnManager.currentTurn >= 0 && turnManager.currentTurn < 20)
                    {
                        SpawnEvent(EventData.EventTier.Tier1);
                    }
                    else if (turnManager.currentTurn >= 20 && turnManager.currentTurn < 40)
                    {
                        Debug.Log("SPawned tier2");
                        SpawnEvent(EventData.EventTier.Tier2);
                    }
                    else if (turnManager.currentTurn >= 40)
                    {
                        SpawnEvent(EventData.EventTier.Tier3);
                    }
                    
                }	
            }					
        }
    }
    public EventPopUpBase GetSelectedEvent()
    {
            return selectedEvent;
    }
		
}