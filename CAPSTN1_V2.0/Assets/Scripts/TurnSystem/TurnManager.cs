using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {
	public static TurnManager instance = null;

	public float currentTurns;
	public bool isTurnEnded;

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

	public void AdvanceTurn()
	{
		if (isTurnEnded == true) 
		{
			
			//Replenish Resources
			//Event Timer goes down
			//Check for solved/Unresolved
			//Deduct/Add region quality to regions
			//Check for collpasing Regions
			//Update region special resource
			//Random Events Pop-up
			//Begin Next Turn
			currentTurns++;
			isTurnEnded = false;
		}
	}
}
