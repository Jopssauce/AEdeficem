using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBase : MonoBehaviour 
{
	 public class Resources
    {
        public int Ap;
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

	public ProductionType firstProduction;
    public ProductionType secondProduction;	

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
	}

	public void UpdateCity()
	{
		firstCurrentProduction = Mathf.RoundToInt( (regionOrigin.regionQuality / regionOrigin.maxRegionQuality) * regionOrigin.MaxRegionResource);

		if (firstCurrentProduction <= 0)
		{
			firstCurrentProduction = 0;
		}
		if (secondCurrentProduction <= 0)
		{
			secondCurrentProduction = 0;
		}
	}
}
