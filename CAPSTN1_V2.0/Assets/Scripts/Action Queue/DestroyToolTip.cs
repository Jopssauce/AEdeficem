using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyToolTip : MonoBehaviour {

	// Update is called once per frame
	void Update () 
	{
		if (Tooltip.IsHover == false) 
		{
			Destroy (this.gameObject);
		}
	}
}
