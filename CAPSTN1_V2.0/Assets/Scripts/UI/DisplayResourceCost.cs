﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayResourceCost : MonoBehaviour {
	public GameObject eventOrigin;
	private ResourceManager resManager;
	public Text waterCost;
	public Text powerCost;
	public Text foodCost;
	public Text actionCost;

	Color waterColor;
	Color powerColor;
	Color foodColor;
	Color actionColor;
	void Start()
	{
		if (ResourceManager.instance != null)
		{
			resManager = ResourceManager.instance;
		}
		waterColor 	= waterCost.color;
		powerColor 	= powerCost.color;
		foodColor 	= foodCost.color;
		actionColor = actionCost.color;
	}
	// Update is called once per frame
	void Update () 
	{
		if (eventOrigin != null)
		{
			waterCost.text = eventOrigin.GetComponent<EventPopUpBase>().eventData.waterCost.ToString();
			powerCost.text = eventOrigin.GetComponent<EventPopUpBase>().eventData.powerCost.ToString();
			foodCost.text = eventOrigin.GetComponent<EventPopUpBase>().eventData.foodCost.ToString();
			actionCost.text = eventOrigin.GetComponent<EventPopUpBase>().eventData.actionCost.ToString();
			
			ChangeColor(waterCost, resManager.water, waterColor);
			ChangeColor(powerCost, resManager.power, powerColor);
			ChangeColor(foodCost, resManager.food, foodColor);
			ChangeColor(actionCost, resManager.actionPoints, actionColor);
		}
	}
	void ChangeColor(Text cost, int currentRes, Color prevColor)
	{
		if (currentRes < System.Int32.Parse( cost.text) )
		{
			cost.color = Color.red;
		}
		else
		{
			cost.color = prevColor;
		}
	}
}