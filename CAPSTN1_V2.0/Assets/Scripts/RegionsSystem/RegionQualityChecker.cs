using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegionQualityChecker : MonoBehaviour 
{

	TurnManager turnManager;
	RegionManager regionManager;

	public Text regQuality1;
	public Text regQuality2;
	public Text regQuality3;
	public Text regQuality4;
	public Text regQuality5;

	void Start()
	{
		
	}

	public void setRegionQualityText()
	{
		if (turnManager != null)
		{
			if (turnManager.currentTurn % 10 == 0)
			{
				regQuality1.text = regionManager.regionList[0].regionQuality.ToString() + "%";
				regQuality2.text = regionManager.regionList[1].regionQuality.ToString() + "%";
				regQuality3.text = regionManager.regionList[2].regionQuality.ToString() + "%";
				regQuality4.text = regionManager.regionList[3].regionQuality.ToString() + "%";
				regQuality5.text = regionManager.regionList[4].regionQuality.ToString() + "%";
			}
		}
	
	}

	public void DisableChecker()
	{
		transform.parent.gameObject.SetActive(false);
	}

	void OnEnable()
	{
		if (TurnManager.instance != null)
		{
			turnManager = TurnManager.instance;
		}
		if (RegionManager.instance != null)
		{
			regionManager = RegionManager.instance;
		}
		setRegionQualityText();
		transform.parent.SetAsLastSibling();
	}
}
