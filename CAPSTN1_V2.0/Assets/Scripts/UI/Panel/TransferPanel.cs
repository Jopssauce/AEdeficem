using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransferPanel : MonoBehaviour 
{
	public RegionBase regionOrigin;
	public CityBase   cityOrigin;
	public List<string> cityNames;

	public Dropdown dropdown;

	public GameObject cityDropdownContentPrefab;
	
	RegionManager regionManager;

	void Start()
	{
		if (RegionManager.instance != null)
		{
			regionManager = RegionManager.instance;
		}
		foreach (var region in regionManager.regionList)
		{
			//GameObject dropdownOptionPrefab = Instantiate();
		
		}
	}
}
