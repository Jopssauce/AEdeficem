using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegionQualityBar : MonoBehaviour {
	public RegionBase 	regionOrigin;
	public Slider 		slider;
	void Start () 
	{
		slider = this.GetComponent<Slider> ();
	}

	void Update () 
	{
		if (regionOrigin != null)
		{
			slider.value = regionOrigin.GetComponent<RegionBase>().regionQuality / regionOrigin.GetComponent<RegionBase>().maxRegionQuality;
		}
	}
}
