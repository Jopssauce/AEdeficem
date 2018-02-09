using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{

	public static EventManager instance = null;

    public Button prefab;
    public Canvas newCanvas;
    public GameObject EventsPanelPrefab;
    public GameObject EventPanel;

    private RegionManager RegionManagerInstance;

    public List<Button> EventList;

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
        EventList = new List<Button>();

        EventPanel = Instantiate(EventsPanelPrefab) as GameObject;
        EventPanel.transform.SetParent(newCanvas.transform, false);
        EventPanel.SetActive(false);

        //Invoke("SpawnEvent",0.1f);
    }

    public void SpawnEvent()
    {
        RegionManagerInstance = RegionManager.instance;

        Button newButton = Instantiate(prefab) as Button;
        newButton.transform.SetParent(newCanvas.transform, false);

        int num = Random.Range(0 , RegionManagerInstance.RegionList.Count);

        //Debug.Log(RegionManagerInstance.RegionList[num].transform.position);

		Vector3 point = Camera.main.WorldToScreenPoint(RandomPointInPolygon(RegionManagerInstance.RegionList[num].GetComponent<BoxCollider>().bounds.center
			, RegionManagerInstance.RegionList[num].GetComponent<BoxCollider>().bounds));

        newButton.GetComponent<EventPopUpBase>().RegionOrigin = RegionManagerInstance.RegionList[num];

        newButton.transform.position = point;

        EventList.Add(newButton);
    }

    private Vector3 RandomPointInPolygon(Vector3 center, Bounds size)
    {
		return center + new Vector3((Random.value - 0.55f) * size.extents.x,(Random.value - 0.55f) * size.extents.y, (Random.value - 0.55f) * size.extents.z);
    }
		
}