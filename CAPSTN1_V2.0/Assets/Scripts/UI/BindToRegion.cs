using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindToRegion : MonoBehaviour {
	public GameObject 	regionOrigin;
	public bool 		randomPoint;
	public float 		offset;
	public Vector3 		randPos;
	// Use this for initialization
	void Start () 
	{
		randPos 	= new Vector3 (Random.value, Random.value, Random.value);
	}

	// Update is called once per frame
	void Update () 
	{
		if (randomPoint == true) 
		{
			this.transform.position = Camera.main.WorldToScreenPoint(RandomPointInPolygon(regionOrigin.GetComponent<BoxCollider>().bounds.center, regionOrigin.GetComponent<BoxCollider>().bounds, randPos) );
		}
		if (randomPoint == false) 
		{
			this.transform.position = Camera.main.WorldToScreenPoint(PointInPolygon(regionOrigin.GetComponent<BoxCollider>().bounds.center, regionOrigin.GetComponent<BoxCollider>().bounds) );
		}
	}
	private Vector3 RandomPointInPolygon(Vector3 center, Bounds size, Vector3 randPos)
	{
		return center + new Vector3((randPos.x - 0.55f) * size.extents.x,(randPos.y - 0.55f) * size.extents.y, (randPos.z - 0.55f) * size.extents.z);
	}
	private Vector3 PointInPolygon(Vector3 center, Bounds size)
	{
		return center + new Vector3((offset) * size.extents.x,(offset) * size.extents.y, (offset) * size.extents.z);
	}
}
