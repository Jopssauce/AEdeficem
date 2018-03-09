using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBase : MonoBehaviour 
{
	[System.Serializable]
	 public class CityResources
    {
        public int Water;
        public int Power;
        public int Food;
    }

    public enum ProductionType
    {
        Water,
        Power,
        Food
    }

	public RegionBase regionOrigin;
	public GameObject cityPanelPrefab;
	public GameObject cityPanel;

	public CityResources 	cityResources;
	public ProductionType 	firstProduction;
    public ProductionType 	secondProduction;	

	public int firstCurrentProduction;
	public int secondCurrentProduction;

	TurnManager turnManager;

	public void Start()
	{
		if (TurnManager.instance != null)
		{
			turnManager = TurnManager.instance;
		}
		turnManager.EndTurnEvent.AddListener(UpdateCity);
		UpdateCity();
	}

	public void UpdateCity()
	{
		firstCurrentProduction = Mathf.RoundToInt( (regionOrigin.regionQuality / regionOrigin.maxRegionQuality) * regionOrigin.MaxRegionResource);
		secondCurrentProduction = Mathf.RoundToInt( (regionOrigin.regionQuality / regionOrigin.maxRegionQuality) * regionOrigin.MaxRegionResource);

		if (firstCurrentProduction <= 0)
		{
			firstCurrentProduction = 0;
		}
		if (secondCurrentProduction <= 0)
		{
			secondCurrentProduction = 0;
		}

		switch (firstProduction)
		{
		case ProductionType.Food:
			cityResources.Food += firstCurrentProduction;
			break;
		case ProductionType.Power:
			cityResources.Power += firstCurrentProduction;
			break;
		case ProductionType.Water:
			cityResources.Water += firstCurrentProduction;
			break;

		default:
			Debug.Log("Error tier list");
			break;
		}

		switch (secondProduction)
		{
		case ProductionType.Food:
			cityResources.Food += secondCurrentProduction;
			break;
		case ProductionType.Power:
			cityResources.Power += secondCurrentProduction;
			break;
		case ProductionType.Water:
			cityResources.Water += secondCurrentProduction;
			break;

		default:
			Debug.Log("Error tier list");
			break;
		}
	}

	public void SpawnStatsPanel()
	{
		cityPanel = Instantiate(cityPanelPrefab);
		cityPanelPrefab.GetComponent<StatsPanel>().cityOrigin = this.GetComponent<CityBase>();
	}
}
