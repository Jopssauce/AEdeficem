using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCityResources : MonoBehaviour {

	public EventPopUpBase eventOrigin;
	private ResourceManager resManager;
	public Text water;
	public Text power;
	public Text food;

	Color waterColor;
	Color powerColor;
	Color foodColor;
	void Start()
	{
		if (ResourceManager.instance != null)
		{
			resManager = ResourceManager.instance;
		}
		waterColor 	= water.color;
		powerColor 	= power.color;
		foodColor 	= food.color;
        resManager.AdjustedResourceEvent.AddListener(UpdateUiText);
    }
	// Update is called once per frame
	void Update () 
	{
		CityBase cityOrgin = eventOrigin.regionOrigin.cityOrigin;
		if (eventOrigin != null)
		{
			water.text = cityOrgin.cityResources.Water.ToString();
			power.text = cityOrgin.cityResources.Power.ToString();
			food.text =  cityOrgin.cityResources.Food.ToString();
			
			ChangeColor(water, cityOrgin.cityResources.Water, waterColor);
			ChangeColor(power, cityOrgin.cityResources.Power, powerColor);
			ChangeColor(food,  cityOrgin.cityResources.Food, foodColor);
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

    // Just needed to be invoked onclick event in eventPopupBase
    // Had to seperate it for now
    void UpdateUiText()
    {
        if (eventOrigin != null)
        {
            water.text = eventOrigin.GetComponent<EventPopUpBase>().eventDataCopy.waterCost.ToString();
            power.text = eventOrigin.GetComponent<EventPopUpBase>().eventDataCopy.powerCost.ToString();
            food.text = eventOrigin.GetComponent<EventPopUpBase>().eventDataCopy.foodCost.ToString();
			
            ChangeColor(water, resManager.water, waterColor);
            ChangeColor(power, resManager.power, powerColor);
            ChangeColor(food, resManager.food, foodColor);
        }
    }
}
