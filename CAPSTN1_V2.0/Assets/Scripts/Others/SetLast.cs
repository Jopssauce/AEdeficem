using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLast : MonoBehaviour {

	void Update ()
	{
		if (this.gameObject != null)
			this.gameObject.transform.SetAsLastSibling ();
	}
}
