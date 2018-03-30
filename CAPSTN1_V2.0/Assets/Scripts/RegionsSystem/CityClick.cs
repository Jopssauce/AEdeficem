using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CityClick : MonoBehaviour {
	public CityBase cityOrigin;
	public GameObject BlockPanel;

	private GameObject blockPanel;

	void Start()
	{
		cityOrigin = GetComponent<CityBase>();
	}

	
	void OnMouseOver()
	{
		if (!EventSystem.current.IsPointerOverGameObject ())
		{
			if (Input.GetMouseButtonDown (0))
			{
				Debug.Log (cityOrigin.name);
				cityOrigin.SpawnStatsPanel ();
				FindObjectOfType<AudioManager> ().Play ("Generic");
			}
		}
	}
	
}
