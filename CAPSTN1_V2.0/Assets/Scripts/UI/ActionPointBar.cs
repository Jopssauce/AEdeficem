using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionPointBar : MonoBehaviour {
	ResourceManager 	resManager;
	//TurnManager			turnManager;
	//EventManager		eventManager;
	public List<Sprite> actionPointBarSprites;
	// Use this for initialization
	void Start () 
	{
		if (ResourceManager.instance != null)
		{
			resManager = ResourceManager.instance;
		}
		
		
		resManager.AdjustedResourceEvent.AddListener(ChangeSprite);
		ChangeSprite();
	}
	
	public void ChangeSprite()
	{
		if (resManager.actionPoints >= 0)
		{
			GetComponent<Image>().sprite = actionPointBarSprites[resManager.actionPoints];
		}
	}
	
}
