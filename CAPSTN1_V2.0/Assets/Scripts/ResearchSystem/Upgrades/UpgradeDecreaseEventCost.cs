using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDecreaseEventCost : Upgrade 
{
	public float decrease;
	public override void UpgradeEffect()
	{
		base.UpgradeEffect();
		setDecreasePercentage();
		foreach (var spawnArea in cityBase.regionOrigin.spawnAreas)
		{
			
			if (spawnArea.GetComponent<SpawnArea>().eventOrigin != null)
			{
				Debug.Log(spawnArea.GetComponent<SpawnArea>().eventOrigin);
				spawnArea.GetComponent<SpawnArea>().eventOrigin.eventDataCopy.waterCost = (int)(spawnArea.GetComponent<SpawnArea>().eventOrigin.eventData.waterCost * decrease);
				spawnArea.GetComponent<SpawnArea>().eventOrigin.eventDataCopy.foodCost =  (int)(spawnArea.GetComponent<SpawnArea>().eventOrigin.eventData.foodCost * decrease);
				spawnArea.GetComponent<SpawnArea>().eventOrigin.eventDataCopy.powerCost = (int)(spawnArea.GetComponent<SpawnArea>().eventOrigin.eventData.powerCost * decrease);
			}
			
		}
	}
	public void setDecreasePercentage()
	{
		if (researchManager.tierProgress.disasterPrepTier == 1)
		{
			decrease = .9f;
		}
		if (researchManager.tierProgress.disasterPrepTier == 2)
		{
			decrease = .8f;
		}
		if (researchManager.tierProgress.disasterPrepTier == 3)
		{
			decrease = .7f;
		}
		if (researchManager.tierProgress.disasterPrepTier == 4)
		{
			decrease = .6f;
		}
		if (researchManager.tierProgress.disasterPrepTier == 0)
		{
			decrease = 1f;
		}
		
	}

}
