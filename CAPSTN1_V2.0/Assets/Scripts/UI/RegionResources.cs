using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegionResources : MonoBehaviour {
	public Text 		regionResources;
	public Image 		resourceImage;
	public GameObject 	regionOrigin;
	
	void Start ()
	{
		
	}

	void Update () 
	{
		if (regionOrigin != null)
		{
			regionResources.text = regionOrigin.GetComponent<RegionBase>().RegionResourceAmount.ToString();
		}
	}
}
