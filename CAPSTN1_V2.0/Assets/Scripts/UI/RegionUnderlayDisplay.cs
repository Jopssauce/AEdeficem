using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegionUnderlayDisplay : MonoBehaviour {
	public GameObject regionOrigin;
	public GameObject regionQualityBar;
	
	void Start ()
	{
		this.GetComponent<BindToRegion>().regionOrigin = this.regionOrigin;
		regionQualityBar.GetComponent<RegionQualityBar>().origin = regionOrigin;
	}

}
