using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegionResources : MonoBehaviour {
	public Text 		resourceAmount;
	public Text			resourceAmount2;
	public Image 		resourceImage;
	public Image 		resourceImage2;
	public RegionBase 	regionOrigin;
	public CityBase		cityOrigin;
	public ResourceManager	resManager;
	
	void Start ()
	{
		cityOrigin = regionOrigin.cityOrigin;
		SetSprite(regionOrigin.cityOrigin.firstProduction, regionOrigin.cityOrigin.secondProduction);
		if (ResourceManager.instance != null) 
		{
			resManager = ResourceManager.instance;
		}
		resManager.AdjustedResourceEvent.AddListener (UpdateUiText);
		cityOrigin.AdjustedCityResource.AddListener (UpdateUiText);
		UpdateUiText ();
		cityOrigin = regionOrigin.cityOrigin;
	}


	void UpdateUiText()
	{
		if (cityOrigin != null)
		{
			resourceAmount.text = "+" + (cityOrigin.firstCurrentProduction + cityOrigin.bonusFirstProd).ToString();
			resourceAmount2.text = "+" + (cityOrigin.secondCurrentProduction + cityOrigin.bonusSecondProd).ToString();
		}
	}
	   
	public void SetSprite(CityBase.ProductionType type, CityBase.ProductionType type2 )
	{
		switch (type) 
		{
		case CityBase.ProductionType.Water:
			resourceImage.sprite = Resources.Load <Sprite>("WaterIcon");
			resourceAmount.color = new Color32(0, 222, 255, 255);
			break;
		case CityBase.ProductionType.Power:
			resourceImage.sprite = Resources.Load <Sprite>("PowerIcon");
			resourceAmount.color = new Color32(255, 228, 0, 255);
			break;
		case CityBase.ProductionType.Food:
			resourceImage.sprite = Resources.Load <Sprite>("FoodIcon");
			resourceAmount.color = new Color32(80, 195, 2, 255);
			break;
		default:
			Debug.Log ("Cant add Sprite");
			break;
		}

		switch (type2) 
		{
		case CityBase.ProductionType.Water:
			resourceImage2.sprite = Resources.Load <Sprite>("WaterIcon");
			resourceAmount2.color = new Color32(0, 222, 255, 255);
			break;
		case CityBase.ProductionType.Power:
			resourceImage2.sprite = Resources.Load <Sprite>("PowerIcon");
			resourceAmount2.color = new Color32(255, 228, 0, 255);
			break;
		case CityBase.ProductionType.Food:
			resourceImage2.sprite = Resources.Load <Sprite>("FoodIcon");
			resourceAmount2.color = new Color32(80, 195, 2, 255);
			break;
		default:
			Debug.Log ("Cant add Sprite");
			break;
		}
	}
}
