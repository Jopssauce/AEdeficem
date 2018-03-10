using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPrefab : MonoBehaviour {
	public EventPopUpBase eventOrigin;
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 pos;
		pos.x = eventOrigin.eventWorldPos.x;
		pos.y = this.transform.position.y;
		pos.z = eventOrigin.eventWorldPos.z;
		this.transform.position = pos;
		this.transform.Rotate(Vector3.up * 50 * Time.deltaTime, Space.Self);
		if (eventOrigin == null)
		{
			Destroy(this.gameObject);
		}
	}
}
