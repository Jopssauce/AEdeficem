using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegionQualityBar : MonoBehaviour {
	public RegionBase 	origin;
	public Slider 		slider;
	void Start () 
	{
		slider = this.GetComponent<Slider> ();
	}

	void Update () 
	{
		slider.value = origin.regionQuality / origin.maxRegionQuality;
	}
}
