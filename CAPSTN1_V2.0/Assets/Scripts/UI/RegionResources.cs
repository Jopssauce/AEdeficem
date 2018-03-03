using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegionResources : MonoBehaviour {
	public Text 		resourceAmount;
	public Image 		resourceImage;
	public GameObject 	regionOrigin;
	
	void Start ()
	{
		SetSprite(regionOrigin.GetComponent<RegionBase>().regionType);
	}

	void Update () 
	{
		if (regionOrigin != null)
		{
			resourceAmount.text = "+" + regionOrigin.GetComponent<RegionBase>().regionResourceAmount.ToString();
		}
	}
	   public void SetSprite(ResourceManager.ResourceType type)
	{
		switch (type) 
		{
		case ResourceManager.ResourceType.ActionPoints:
			resourceImage.sprite = Resources.Load <Sprite>("ManpowerIcon");
			resourceAmount.color = new Color32(253, 161, 3, 255);
			break;
		case ResourceManager.ResourceType.Water:
			resourceImage.sprite = Resources.Load <Sprite>("WaterIcon");
			resourceAmount.color = new Color32(0, 222, 255, 255);
			break;
		case ResourceManager.ResourceType.Power:
			resourceImage.sprite = Resources.Load <Sprite>("PowerIcon");
			resourceAmount.color = new Color32(255, 228, 0, 255);
			break;
		case ResourceManager.ResourceType.Food:
			resourceImage.sprite = Resources.Load <Sprite>("FoodIcon");
			resourceAmount.color = new Color32(80, 195, 2, 255);
			break;
		default:
			Debug.Log ("Cant add Sprite");
			break;
		}
	}
}
