using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeRegionPlan : Upgrade {

	public bool tier1;
	public bool tier2;
	public bool tier3;
	public bool tier4;

	public override void UpgradeEffect()
	{
		base.UpgradeEffect();
		if (researchManager.tierProgress.regionalPlanTier >= 1)
		{
			if (tier1 == false)
			{
				cityBase.bonusWater += 1;
				cityBase.bonusFood += 1;
				cityBase.bonusPower += 1;
				tier1 = true;
			}
			
		}
		if (researchManager.tierProgress.regionalPlanTier >= 2)
		{
			if (tier2 == false)
			{
				cityBase.bonusResourceSlots += 1;
				tier2 = true;
			}
		}
		if (researchManager.tierProgress.regionalPlanTier >= 3)
		{
			if (tier3 == false)
			{
				cityBase.regionOrigin.regionDecayTimer += 2;
				tier3 = true;
			}
		}
			if (researchManager.tierProgress.regionalPlanTier >= 4)
		{
			if (tier4 == false)
			{
				cityBase.regionOrigin.maxEvents += 1;
				tier4 = true;
			}
		}
	}
}
