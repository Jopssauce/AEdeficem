using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegionUnderlayDisplay : MonoBehaviour {
	public GameObject regionOrigin;
	public GameObject regionQualityBar;
	public GameObject regionResources;
	void Start ()
	{
		this.GetComponent<BindToRegion>().regionOrigin 					= this.regionOrigin;
		regionQualityBar.GetComponent<RegionQualityBar>().regionOrigin 	= regionOrigin;
		regionResources.GetComponent<RegionResources>().regionOrigin 	= this.regionOrigin;
	}

}
