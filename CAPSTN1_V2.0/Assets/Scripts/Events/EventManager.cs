using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{

	public static EventManager instance = null;

    public Button prefab;
    public Canvas newCanvas;

    public RegionManager RegionManagerInstance;

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

        //Invoke("SpawnEvent",0.1f);
    }

    public void SpawnEvent()
    {
        RegionManagerInstance = RegionManager.instance;

        Button newButton = Instantiate(prefab) as Button;
        newButton.transform.SetParent(newCanvas.transform, false);

        int num = Random.Range(0 , RegionManagerInstance.RegionList.Count);

        //Debug.Log(RegionManagerInstance.RegionList[num].transform.position);

        Vector2 point = Camera.main.WorldToScreenPoint(RandomPointInBox(RegionManagerInstance.RegionList[num].transform.position, RegionManagerInstance.RegionList[num].transform.localScale));

        newButton.GetComponent<EventPopUpBase>().RegionOrigin = RegionManagerInstance.RegionList[num];

        newButton.transform.position = point;

        EventList.Add(newButton);
    }

    private Vector2 RandomPointInBox(Vector2 center, Vector2 size)
    {
        return center + new Vector2((Random.value - 0.5f) * size.x,(Random.value - 0.5f) * size.y);
    }
}