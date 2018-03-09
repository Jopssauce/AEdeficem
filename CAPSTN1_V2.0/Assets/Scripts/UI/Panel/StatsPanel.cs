using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPanel : MonoBehaviour 
{
	public RegionBase	regionOrigin;
	public CityBase 	cityOrigin;

	public Text cityName;

	public Text waterAmount;
	public Text	foodAmount;
	public Text powerAmount;

	public Image waterImage;
	public Image foodImage2;
	public Image powerImage3;

	public Button exitButton;
	
	public void exitClick()
	{
		Destroy(this.gameObject);
	}
}
