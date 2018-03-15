using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDecreaseEventCost : Upgrade 
{
	public override void UpgradeEffect()
	{
		base.UpgradeEffect();
		foreach (var spawnArea in cityBase.regionOrigin.spawnAreas)
		{
			
			if (spawnArea.GetComponent<SpawnArea>().eventOrigin != null)
			{
				Debug.Log(spawnArea.GetComponent<SpawnArea>().eventOrigin);
				spawnArea.GetComponent<SpawnArea>().eventOrigin.eventDataCopy.waterCost = (int)(spawnArea.GetComponent<SpawnArea>().eventOrigin.eventData.waterCost * 0.8f);
				spawnArea.GetComponent<SpawnArea>().eventOrigin.eventDataCopy.foodCost =  (int)(spawnArea.GetComponent<SpawnArea>().eventOrigin.eventData.foodCost * 0.8f);
				spawnArea.GetComponent<SpawnArea>().eventOrigin.eventDataCopy.powerCost = (int)(spawnArea.GetComponent<SpawnArea>().eventOrigin.eventData.powerCost * 0.8f);
			}
			
		}
	}

}
