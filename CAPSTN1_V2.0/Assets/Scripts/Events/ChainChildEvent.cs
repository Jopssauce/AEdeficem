using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChainChildEvent : EventPopUpBase 
{
	public ChainEvent eventOrigin;

	public override void UpdateEvent()
	{
		if (isResolved == true)
        {
            regionOrigin.GetComponent<RegionBase>().regionQuality += eventDataCopy.qualityDecay *regionOrigin.GetComponent<RegionBase>().maxRegionQuality;
            turnsLeft = 0;
            Destroy(this.gameObject);
           	eventOrigin.persistentEvents.Remove(this.gameObject);
        }
        
	}
}
