using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;


public class TurnManager : MonoBehaviour {
	public static TurnManager 	instance = null;
	public ResourceManager 		resManager;
	public EventManager 		eventManager;
	public RegionManager		regionManager;
	public AQManager 			aqManager;
	
	public float 				currentTurn;
	public bool 				isTurnEnded;
	public bool 				victory;
	public bool 				defeat;

	public int 					sustainableRegions;
	[SerializeField]
	public UnityEvent EndTurnEvent;

	void Awake()
	{
		if (instance == null) 
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy (this.gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}
	
	void Start()
	{
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
        if (AQManager.instance != null)
        {
            aqManager = AQManager.instance;
        }
		AdvanceTurn();
		EndTurnEvent.AddListener(AdvanceTurn);
		EndTurnEvent.AddListener(eventManager.UpdateEvents);
		EndTurnEvent.AddListener(regionManager.UpdateRegion);
		resManager.GetResourceSum();
		
		victory = true;
		defeat = true;
		//AdvanceTurn();
	}

	public void AdvanceTurn()
	{
		resManager.AddResource(ResourceManager.ResourceType.ActionPoints, 10 - resManager.actionPoints );
		currentTurn++;
		sustainableRegions = 0;		
	}
	
}