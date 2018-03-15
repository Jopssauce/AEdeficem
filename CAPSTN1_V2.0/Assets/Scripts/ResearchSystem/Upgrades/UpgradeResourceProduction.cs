using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeResourceProduction : Upgrade
{
	public override void Start()
	{
		base.Start();
		turnManager.EndTurnEvent.AddListener(UpgradeEffect);
	}
	public override void UpgradeEffect()
	{
		base.UpgradeEffect();
		IncreaseProduction();
		//IncreaseFirstProduction();
		//IncreaseSecondProduction();
	}

	public void IncreaseFirstProduction()
	{
		switch (cityBase.firstProduction)
		{
			case CityBase.ProductionType.Water :
			if (researchManager.tierProgress.resourceProdTier >= 2)
			{
				cityBase.bonusFirstProd = 1;
			}
			break;
			case CityBase.ProductionType.Food :
			if (researchManager.tierProgress.resourceProdTier >= 1)
			{
				cityBase.bonusFirstProd = 1;
			}
			break;
			case CityBase.ProductionType.Power :
			if (researchManager.tierProgress.resourceProdTier >= 3)
			{
				cityBase.bonusFirstProd = 1;
			}
			break;
			default:
			break;
		}
	}
	public void IncreaseSecondProduction()
	{
		switch (cityBase.secondProduction)
		{
			case CityBase.ProductionType.Water :
			if (researchManager.tierProgress.resourceProdTier >= 2)
			{
				cityBase.bonusSecondProd = 1;
			}
			break;
			case CityBase.ProductionType.Food :
			if (researchManager.tierProgress.resourceProdTier >= 1)
			{
				cityBase.bonusSecondProd = 1;
			}
			break;
			case CityBase.ProductionType.Power :
			if (researchManager.tierProgress.resourceProdTier >= 3)
			{
				cityBase.bonusSecondProd = 1;
			}
			break;
			default:
			break;
		}
	}
	public void IncreaseProduction()
	{
			if (researchManager.tierProgress.resourceProdTier >= 1)
			{
				if (cityBase.firstProduction == CityBase.ProductionType.Water)
				{
					cityBase.bonusFirstProd = 1;
				}
				if (cityBase.secondProduction == CityBase.ProductionType.Water)
				{
					cityBase.bonusSecondProd = 1;
				}
			}
			if (researchManager.tierProgress.resourceProdTier >= 2)
			{
				if (cityBase.firstProduction == CityBase.ProductionType.Food)
				{
					cityBase.bonusFirstProd = 1;
				}
				if (cityBase.secondProduction == CityBase.ProductionType.Food)
				{
					cityBase.bonusSecondProd = 1;
				}
			}
			if (researchManager.tierProgress.resourceProdTier >= 3)
			{
				if (cityBase.firstProduction == CityBase.ProductionType.Power)
				{
					cityBase.bonusFirstProd = 1;
				}
				if (cityBase.secondProduction == CityBase.ProductionType.Power)
				{
					cityBase.bonusSecondProd = 1;
				}
			}
			if (researchManager.tierProgress.resourceProdTier >= 4)
			{	
				cityBase.bonusFirstProd = 2;
				cityBase.bonusSecondProd = 2;
			}
	}
	
}
