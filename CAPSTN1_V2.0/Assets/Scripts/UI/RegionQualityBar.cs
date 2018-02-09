using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegionQualityBar : MonoBehaviour {
	public GameObject 	origin;
	public Slider 		slider;
	void Start () 
	{
		slider = this.GetComponent<Slider> ();
		this.GetComponent<BindToRegion>().regionOrigin = origin;
	}

	void Update () 
	{
		slider.value = origin.GetComponent<RegionBase>().regionQuality / origin.GetComponent<RegionBase>().maxRegionQuality;
	}
}
