using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{

	public static EventManager instance = null;

    public GameObject   prefab;
    public Canvas       newCanvas;
    public GameObject   EventsPanelPrefab;
    public GameObject   EventPanel;
    public EventsList   eventsList;
    
    private RegionManager RegionManagerInstance;

    public List<GameObject> eventTracker;

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
        EventPanel = Instantiate(EventsPanelPrefab) as GameObject;
        EventPanel.transform.SetParent(newCanvas.transform, false);
        EventPanel.SetActive(false);
    }

    public void SpawnEvent(EventData.EventTier eventTier)
    {
        RegionManagerInstance = RegionManager.instance;

		int num 			    = Random.Range(0 , RegionManagerInstance.regionList.Count);
        GameObject newButton    = Instantiate(prefab);

        newButton.transform.SetParent(newCanvas.transform, false);

		newButton.GetComponent<EventPopUpBase>().regionOrigin = RegionManagerInstance.regionList[num];

        if (eventTier == EventData.EventTier.Tier1)
        {
           
        }
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

        newButton.GetComponent<EventPopUpBase>().turnsLeft    = newButton.GetComponent<EventPopUpBase>().eventData.turnsLeft;
        eventTracker.Add(newButton);
    }

    private Vector3 RandomPointInPolygon(Vector3 center, Bounds size)
    {
		return center + new Vector3((Random.value - 0.55f) * size.extents.x,(Random.value - 0.55f) * size.extents.y, (Random.value - 0.55f) * size.extents.z);
    }
		
}