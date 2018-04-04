using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegionUnderlayDisplay : MonoBehaviour {
	public RegionBase regionOrigin;
	public GameObject regionQualityBar;
	public GameObject regionResources;
	
	public Text waterAmt;
	public Text foodAmt;
	public Text powerAmt;

	public Text regionName;
	void Start ()
	{	
		regionQualityBar.GetComponent<RegionQualityBar>().regionOrigin 	= regionOrigin;
		regionResources.GetComponent<RegionResources>().regionOrigin 	= this.regionOrigin;
		regionName.text = regionOrigin.name;
		SetUIText();
		regionOrigin.cityOrigin.AdjustedCityResource.AddListener(SetUIText);
	
	}

	void ChangeColor(Text cost, Color prevColor)
	{
		if ( System.Int32.Parse( cost.text) <= 4 )
		{
			cost.color = Color.red;
		}
		else
		{
			cost.color = prevColor;
		}
	}

	public void SetUIText()
	{
		waterAmt.text 	= regionOrigin.cityOrigin.cityResources.Water.ToString();
		foodAmt.text 	= regionOrigin.cityOrigin.cityResources.Food.ToString();
		powerAmt.text 	= regionOrigin.cityOrigin.cityResources.Power.ToString();
		ChangeColor(waterAmt, Color.white);
		ChangeColor(foodAmt, Color.white);
		ChangeColor(powerAmt, Color.white);
	}

}
