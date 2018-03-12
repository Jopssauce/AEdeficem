using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class StatsPanel : MonoBehaviour 
{
	public RegionBase regionOrigin;
	public CityBase   cityOrigin;

	public GameObject transferPanelPrefab;
	public GameObject transferPanel;

	public Text cityName;
	public Text waterAmount;
	public Text	foodAmount;
	public Text powerAmount;

	public Image waterImage;
	public Image foodImage2;
	public Image powerImage3;

	public Button exitButton;
	public Button transferButton;

	public GameObject BlockerPanel;

	private TurnManager turnManager;

	public RegionUnderlayDisplay regionUnderlayDisplay;
	
	public void Start()
	{
		if (TurnManager.instance != null)
		{
			turnManager = TurnManager.instance;
		}
		turnManager.EndTurnEvent.AddListener(SetUIText);
		cityOrigin.AdjustedCityResource.AddListener(SetUIText);
		SetUIText();
		regionUnderlayDisplay.regionOrigin = this.regionOrigin;
	}

	public void SetUIText()
	{
		waterAmount.text 	= cityOrigin.cityResources.Water.ToString();
		foodAmount.text 	= cityOrigin.cityResources.Food.ToString();
		powerAmount.text 	= cityOrigin.cityResources.Power.ToString();
	}

	public void exitClick()
	{
		Destroy(this.gameObject);
	}
	public void transferButtonClick()
	{
		transferPanel = Instantiate(transferPanelPrefab);
		transferPanel.GetComponent<TransferPanel>().cityOrigin = this.cityOrigin;
		transferPanel.GetComponent<TransferPanel>().regionOrigin = regionOrigin;
		transferPanel.transform.SetParent(GameObject.FindGameObjectWithTag("Main UI").transform, false);
		transferPanel.transform.SetAsLastSibling();
		Destroy(this.gameObject);
	}
}
