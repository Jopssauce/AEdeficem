using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransferPanel : MonoBehaviour 
{
	public RegionBase regionOrigin;

	public CityBase   	cityOrigin;
	public CityBase		cityTarget;
	public List<string> cityNames;

	public Dropdown dropdown;
	public Button exitButton;

	public GameObject cityDropdownContentPrefab;
	
	RegionManager regionManager;
	ResourceManager resourceManager;

	void Start()
	{
		if (RegionManager.instance != null)
		{
			regionManager = RegionManager.instance;
		}
		if (ResourceManager.instance != null)
		{
			resourceManager = ResourceManager.instance;
		}
		foreach (var region in regionManager.regionList)
		{
			//GameObject dropdownOptionPrefab = Instantiate();
		
		}
		cityTarget = regionManager.regionList[0].cityOrigin;
	}

	public void SpawnUnit()
    {
        cityOrigin.SpawnResourceSender(regionManager.regionList[dropdown.value].cityOrigin);
        resourceManager.DeductResource(ResourceManager.ResourceType.ActionPoints, 1);

        Destroy(this.gameObject);   
    }

	public void exitClick()
	{
		Destroy(this.gameObject);
	}

}
