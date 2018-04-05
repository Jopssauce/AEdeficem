using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

	public Slider slider;
	public Text progressText;
	
	RegionManager regionManager;
	TurnManager turnManager;
	// Use this for initialization
	void Start () 
	{
		if (RegionManager.instance != null)
		{
			regionManager = RegionManager.instance;
		}
		if (TurnManager.instance != null)
		{
			turnManager = TurnManager.instance;
		}
		turnManager.EndTurnEvent.AddListener(UpdateProgress);
	}
	
	
	void UpdateProgress()
	{
		float rqSum = 0;
		foreach (var item in regionManager.regionList)
		{
			rqSum += item.regionQuality;
		}
		rqSum /= 500;
		slider.value = rqSum;
		float progressNum = rqSum * 100.0f;
		progressText.text = "Region Quality Average: " + progressNum.ToString() + "%";
	}
}
