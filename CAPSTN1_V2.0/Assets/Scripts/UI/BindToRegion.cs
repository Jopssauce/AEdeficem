using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindToRegion : MonoBehaviour {
	public RegionBase 	regionOrigin;
	public bool 		randomPoint;
	public float 		offset;
	public Vector3 		randPos;
	public GameObject	spawnArea;
	public Vector3 		worldPos;
	public Vector3     	uiPos;
	// Use this for initialization
	void Start () 
	{
		//randPos = new Vector3 (Random.value, Random.value, Random.value);
		spawnArea = regionOrigin.spawnAreas[ Random.Range(0, regionOrigin.spawnAreas.Count)];
	}

	// Update is called once per frame
	void Update () 
	{
		if (spawnArea != null)
		{
			if (randomPoint == true) 
			{
				
				worldPos.x = Camera.main.WorldToScreenPoint((spawnArea.transform.position)).x + 15;
				worldPos.y = Camera.main.WorldToScreenPoint((spawnArea.transform.position )).y + 30;
				worldPos.z = Camera.main.WorldToScreenPoint((spawnArea.transform.position)).z;
				this.transform.position = worldPos;
				
				if (this.GetComponent<EventPopUpBase>() != null )
				{
					this.GetComponent<EventPopUpBase>().eventWorldPos = spawnArea.transform.position;
				}
			}
			if (randomPoint == false) 
			{
				this.transform.position = Camera.main.WorldToScreenPoint(regionOrigin.cityOrigin.transform.position );
			}
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
