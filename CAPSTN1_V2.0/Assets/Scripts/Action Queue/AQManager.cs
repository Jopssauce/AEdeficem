using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AQManager : MonoBehaviour {

    public static AQManager instance = null;
    public GameObject Panel;
    public GameObject ParentPrefab;
	public GameObject ActionQueue;
    public GameObject EventOrigin { get; set; }
    public Text EventText;

    private TurnManager turnManagerInstance;
    private EventManager eventManagerInstance;
    private GameObject NewQueueItem;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
		if (TurnManager.instance != null) 
		{
			turnManagerInstance = TurnManager.instance;
		}

        if (EventManager.instance != null)
        {
            eventManagerInstance = EventManager.instance;
        }

        //turnManagerInstance.EndTurnEvent.AddListener(RemoveActionUI);
        //eventManagerInstance.ResolvedEvent.AddListener(InstantiateThePrefab);
    }

    public void RemoveActionUI()
    {
        Panel.SetActive(false);
        foreach (Transform child in ParentPrefab.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

	public void InstantiateThePrefab()
	{
        Debug.Log("Spawned");
		Panel.SetActive(true);
		NewQueueItem = Instantiate(ActionQueue) as GameObject;
		NewQueueItem.transform.SetParent(ParentPrefab.transform, false);
        eventManagerInstance.GetSelectedEvent(); // this should be able to get text
        //EventOrigin.GetComponent<EventPopUpBase>().isResolved = true;
	}
}
