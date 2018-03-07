using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildEvent : EventPopUpBase 
{
	public GameObject regionOrigin;
	public GameObject eventOrigin;

	void Start()
	{
		this.GetComponent<BindToRegion> ().regionOrigin = this.regionOrigin;
	}

}
