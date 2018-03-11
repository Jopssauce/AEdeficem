using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransferPanel : MonoBehaviour 
{
	public RegionBase regionOrigin;

	public CityBase   	cityOrigin;
	public CityBase		cityTarget;

	public List<RegionBase> regionListCopy;
	public List<string> cityName;


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
		regionListCopy = new List<RegionBase>(regionManager.regionList);
		regionListCopy.Remove(regionOrigin);

		foreach (var item in regionListCopy)
		{
			cityName.Add(item.cityOrigin.name);
		}
		dropdown.AddOptions(cityName);
		
	}

	public void SpawnUnit()
    {
        cityOrigin.SpawnResourceSender(regionListCopy[dropdown.value].cityOrigin);
        resourceManager.DeductResource(ResourceManager.ResourceType.ActionPoints, 2);

        Destroy(this.gameObject);   
    }

	public void exitClick()
	{
		Destroy(this.gameObject);
	}

}
