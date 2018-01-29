using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {
	public static TurnManager instance = null;
	public ResourceManager 	resManager;
	public EventManager 	eventManager;
	public float 	currentTurn;
	public int 		turns;
	public bool 	isTurnEnded;

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
	}

	public void AdvanceTurn()
	{
		if (isTurnEnded == true) 
		{
			//Replenish Resources
			if (resManager != null)
			{
				resManager.ReplenishResource();
			}
			//Event Timer goes down

			//Check for solved/Unresolved
			//Deduct/Add region quality to regions
			//Check for collpasing Regions
			//Update region special resource
			//Random Events Pop-up
			//Begin Next Turn
			currentTurn++;
			isTurnEnded = false;
		}
	}
}
