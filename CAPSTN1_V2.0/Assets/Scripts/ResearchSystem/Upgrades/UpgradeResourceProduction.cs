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
		IncreaseFirstProduction();
		IncreaseSecondProduction();
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
	
}
