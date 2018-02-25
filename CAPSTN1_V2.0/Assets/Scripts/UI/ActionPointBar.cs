using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionPointBar : MonoBehaviour {
	ResourceManager 	resManager;
	TurnManager			turnManager;
	public List<Sprite> actionPointBarSprites;
	// Use this for initialization
	void Start () 
	{
		if (ResourceManager.instance != null)
		{
			resManager = ResourceManager.instance;
		}
		if (TurnManager.instance != null)
		{
			turnManager = TurnManager.instance;
		}
		turnManager.EndTurnEvent.AddListener(ChangeSprite);
	}
	
	public void ChangeSprite()
	{
		GetComponent<Image>().sprite = actionPointBarSprites[resManager.actionPoints - 1];
	}
	
}
