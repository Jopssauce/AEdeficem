using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
	public GameObject baseUnitPrefab;
	public GameObject unitResourceSenderPrefab;
	public GameObject RightClickPanel;
	public GameObject rightClickPanel { get; set;}

	public List<GameObject> baseUnits;
	public List<GameObject> unitResourceSenders;

	public CityResources 	cityResources;
	public ProductionType 	firstProduction;
    public ProductionType 	secondProduction;	

	public int firstCurrentProduction;
	public int secondCurrentProduction;

	public int maxFirstProd;
	public int maxSecondProd;

	public int bonusWater;
	public int bonusFood;
	public int bonusPower;

	public int bonusFirstProd;
	public int bonusSecondProd;

	public int bonusResourceSlots;

	public int regionDecayTimer;


	private TurnManager turnManager;
	public UnityEvent AdjustedCityResource;
	public void Start()
	{
		if (TurnManager.instance != null)
		{
			turnManager = TurnManager.instance;
		}
		turnManager.EndTurnEvent.AddListener(UpdateCity);
		UpdateCity();
		maxFirstProd = 6;
		maxSecondProd = 6;
		
	}

	public void UpdateCity()
	{
		firstCurrentProduction = Mathf.RoundToInt( (regionOrigin.regionQuality / regionOrigin.maxRegionQuality) * maxFirstProd);
		secondCurrentProduction = Mathf.RoundToInt( (regionOrigin.regionQuality / regionOrigin.maxRegionQuality) * maxSecondProd);
		ApplyBonusResource();
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
		case ProductionType.Water:
			cityResources.Water += firstCurrentProduction + bonusFirstProd;
			break;
		case ProductionType.Food:
			cityResources.Food += firstCurrentProduction + bonusFirstProd;
			break;
		case ProductionType.Power:
			cityResources.Power += firstCurrentProduction + bonusFirstProd;
			break;

		default:
			Debug.Log("Error tier list");
			break;
		}

		switch (secondProduction)
		{
		case ProductionType.Water:
			cityResources.Water += secondCurrentProduction + bonusSecondProd;
			break;
		case ProductionType.Food:
			cityResources.Food += secondCurrentProduction + bonusSecondProd;
			break;
		case ProductionType.Power:
			cityResources.Power += secondCurrentProduction + bonusSecondProd;
			break;

		default:
			Debug.Log("Error tier list");
			break;
		}
		if (cityResources.Water <= 0)
		{
			cityResources.Water = 0;
		}
		if (cityResources.Food <= 0)
		{
			cityResources.Food = 0;
		}
		if (cityResources.Power <= 0)
		{
			cityResources.Power = 0;
		}
		AdjustedCityResource.Invoke();
	}

	public void SpawnStatsPanel()
	{
		cityPanel = Instantiate(cityPanelPrefab);
		cityPanel.GetComponent<StatsPanel>().cityOrigin = this.GetComponent<CityBase>();
		cityPanel.GetComponent<StatsPanel>().regionOrigin = regionOrigin;
		cityPanel.transform.SetParent(GameObject.FindGameObjectWithTag("Main UI").transform, false);
		cityPanel.transform.SetAsLastSibling();
	}
		
	public void SpawnRightClickPanel()
	{
		rightClickPanel = Instantiate (RightClickPanel);
		rightClickPanel.transform.SetParent(GameObject.FindGameObjectWithTag("Main UI").transform, false);
		rightClickPanel.transform.SetAsLastSibling();
		rightClickPanel.GetComponent<BindToRegion> ().regionOrigin = this.regionOrigin;
	}

	public void DeductCityResource(CityBase.ProductionType type, int amount)
	{
		switch (type) 
		{
		case CityBase.ProductionType.Food:
			cityResources.Food -= amount;
			break;
		case CityBase.ProductionType.Power:
			cityResources.Power -= amount;
			break;
		case CityBase.ProductionType.Water:
			cityResources.Water -= amount;
			break;
		default:
			Debug.Log ("Cant deduct Resource");
			break;
		}
		AdjustedCityResource.Invoke ();
	}
	public void AddCityResource(CityBase.ProductionType type, int amount)
	{
		switch (type) 
		{
		case CityBase.ProductionType.Food:
			cityResources.Food += amount;
			break;
		case CityBase.ProductionType.Power:
			cityResources.Power += amount;
			break;
		case CityBase.ProductionType.Water:
			cityResources.Water += amount;
			break;
		default:
			Debug.Log ("Cant add Resource");
			break;
		}
		AdjustedCityResource.Invoke ();
	}
	public void SpawnUnit(EventPopUpBase eventBase)
	{
		Vector3 spawnPos;
		spawnPos.x = this.transform.position.x;
		spawnPos.y = baseUnitPrefab.transform.position.y;
		spawnPos.z = this.transform.position.z;
		GameObject currentUnit = Instantiate(baseUnitPrefab, spawnPos, this.transform.rotation);
		currentUnit.GetComponent<UnitBase>().cityOrigin = this;
		currentUnit.GetComponent<UnitBase>().eventOrigin = eventBase;
		baseUnits.Add(currentUnit);
	}
	
	public void SpawnResourceSender(CityBase cityTarget, int water, int food, int power)
	{
		Vector3 spawnPos;
		spawnPos.x = this.transform.position.x;
		spawnPos.y = baseUnitPrefab.transform.position.y;
		spawnPos.z = this.transform.position.z;
		GameObject currentUnit = Instantiate(unitResourceSenderPrefab, spawnPos, this.transform.rotation);
		UnitResourceSender resourceSender = currentUnit.GetComponent<UnitResourceSender>();
		resourceSender.cityOrigin = this;
		resourceSender.target = cityTarget;

		resourceSender.StoreResource(ProductionType.Water, water);
		resourceSender.StoreResource(ProductionType.Food, food);
		resourceSender.StoreResource(ProductionType.Power, power);
		
		unitResourceSenders.Add(currentUnit);
	}

	public void ApplyBonusResource()
	{
		if (firstProduction == CityBase.ProductionType.Water)
		{
			bonusFirstProd = bonusWater;
		}
		if (secondProduction == CityBase.ProductionType.Water)
		{
			bonusSecondProd = bonusWater;
		}
		if (firstProduction == CityBase.ProductionType.Food)
		{
			bonusFirstProd = bonusFood;
		}
		if (secondProduction == CityBase.ProductionType.Food)
		{
			bonusSecondProd = bonusFood;
		}
		if (firstProduction == CityBase.ProductionType.Power)
		{
			bonusFirstProd = bonusPower;
		}
		if (secondProduction == CityBase.ProductionType.Power)
		{
			bonusSecondProd = bonusPower;
		}
	}

}
