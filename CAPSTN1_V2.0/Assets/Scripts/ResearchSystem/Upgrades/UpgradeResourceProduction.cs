using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeResourceProduction : Upgrade
{
	public bool tier1;
	public bool tier2;
	public bool tier3;
	public bool tier4;
	
	public override void Start()
	{
		base.Start();
		tier1 = false;
		tier2 = false;
		tier3 = false;
		tier4 = false;
	}
	public override void UpgradeEffect()
	{
		base.UpgradeEffect();
		IncreaseProduction();

	}
	public void IncreaseProduction()
	{
		if (researchManager.tierProgress.resourceProdTier >= 1)
		{
			if (cityBase.firstProduction == CityBase.ProductionType.Water)
			{
				if (tier1 == false)
				{
					cityBase.bonusWater += 1;
					tier1 = true;
				}
				
			}
			if (cityBase.secondProduction == CityBase.ProductionType.Water)
			{
				if (tier1 == false)
				{
					cityBase.bonusWater += 1;
					tier1 = true;
				}
				
			}
		}
		if (researchManager.tierProgress.resourceProdTier >= 2)
		{
			if (cityBase.firstProduction == CityBase.ProductionType.Food)
			{
				if (tier2 == false)
				{
					cityBase.bonusFood += 1;
					tier2 = true;
				}
				
			}
			if (cityBase.secondProduction == CityBase.ProductionType.Food)
			{
				if (tier2 == false)
				{
					cityBase.bonusFood += 1;
					tier2 = true;
				}
				
			}
		}
		if (researchManager.tierProgress.resourceProdTier >= 3)
		{
			if (cityBase.firstProduction == CityBase.ProductionType.Power)
			{
				if (tier3 == false)
				{
					cityBase.bonusPower += 1;
					tier3 = true;
				}
				
			}
			if (cityBase.secondProduction == CityBase.ProductionType.Power)
			{
				if (tier3 == false)
				{
					cityBase.bonusPower += 1;
					tier3 = true;
				}
				
			}
		}
		if (researchManager.tierProgress.resourceProdTier >= 4)
		{	
			if (tier4 == false)
			{
				cityBase.bonusWater += 1;
				cityBase.bonusFood += 1;
				cityBase.bonusPower += 1;
				tier4 = true;
			}
		}
	
	}
	
}
