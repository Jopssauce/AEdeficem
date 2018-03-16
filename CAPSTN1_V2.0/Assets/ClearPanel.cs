using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearPanel : MonoBehaviour 
{
	public void DestroyParent()
	{
		Destroy (this.transform.parent.transform.gameObject);
	}
}
