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

    public void SpawnEvent()
    {
        RegionManagerInstance = RegionManager.instance;

		int num 			    = Random.Range(0 , RegionManagerInstance.regionList.Count);
        GameObject newButton    = Instantiate(prefab);

        newButton.transform.SetParent(newCanvas.transform, false);

		newButton.GetComponent<EventPopUpBase>().regionOrigin = RegionManagerInstance.regionList[num];
        //newButton.GetComponent<EventPopUpBase>().eventData      = new EventData();
        newButton.GetComponent<EventPopUpBase>().eventData    = eventsList.eventDataList[Random.Range(0, eventsList.eventDataList.Count)];
        newButton.GetComponent<EventPopUpBase>().turnsLeft    = newButton.GetComponent<EventPopUpBase>().eventData.turnsLeft;
        eventTracker.Add(newButton);
    }

    private Vector3 RandomPointInPolygon(Vector3 center, Bounds size)
    {
		return center + new Vector3((Random.value - 0.55f) * size.extents.x,(Random.value - 0.55f) * size.extents.y, (Random.value - 0.55f) * size.extents.z);
    }
		
}