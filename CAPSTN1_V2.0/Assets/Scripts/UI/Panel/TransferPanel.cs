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

	public Text waterAmount;
	public Text	foodAmount;
	public Text powerAmount;

	public InputField waterInput;
	public InputField foodInput;
	public InputField powerInput;

	public Dropdown dropdown;
	public Button exitButton;

	public GameObject cityDropdownContentPrefab;
	
	RegionManager regionManager;
	ResourceManager resourceManager;
	TurnManager turnManager;
	TutorialManager tutorialManager;
	

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
		if (TurnManager.instance != null)
		{
			turnManager = TurnManager.instance;
		}
		tutorialManager = cityOrigin.tutorialManager;
		turnManager.EndTurnEvent.AddListener(SetUIText);
		regionListCopy = new List<RegionBase>(regionManager.regionList);
		regionListCopy.Remove(regionOrigin);

		foreach (var item in regionListCopy)
		{
			cityName.Add(item.cityOrigin.name);
		}
		dropdown.AddOptions(cityName);
		SetUIText();
		
	}

	public void SpawnUnit()
    {
		if (isEnoughRes() == true)
		{
			if (tutorialManager != null)
			{
				if (tutorialManager.currentTutorialStepPanel != null)
				{
					if (tutorialManager.currentTutorialStepPanel.GetComponent<TransferStep2>())
					{
						tutorialManager.currentTutorialStepPanel.GetComponent<TransferStep2>().isStepDone = true;
						tutorialManager.currentTutorialStepPanel.GetComponent<TransferStep2>().nextButtonClick();
					}
				}           
			}
			cityOrigin.SpawnResourceSender(regionListCopy[dropdown.value].cityOrigin, int.Parse(waterInput.text), int.Parse(foodInput.text), int.Parse(powerInput.text));
        	resourceManager.DeductResource(ResourceManager.ResourceType.ActionPoints, 2);
			SetUIText();
			//Destroy (CityBase.blockerPanel);
			Destroy(this.gameObject);   
			FindObjectOfType<AudioManager> ().Play ("Generic");
		}
        
    }

	public void exitClick()
	{
		Destroy(this.gameObject);
	}
	  public bool isEnoughRes()
	{
        CityBase cityOrigin = regionOrigin.cityOrigin;
		FindObjectOfType<AudioManager> ().Play ("Generic");
		if (cityOrigin.cityResources.Water < int.Parse(waterInput.text) || cityOrigin.cityResources.Food < int.Parse(foodInput.text) 
		 || cityOrigin.cityResources.Power < int.Parse(powerInput.text) )
		{
			return false;
		}
		else
		{
			return true;
		}
		
		
	}

	public void SetUIText()
	{
		waterAmount.text 	= cityOrigin.cityResources.Water.ToString();
		foodAmount.text 	= cityOrigin.cityResources.Food.ToString();
		powerAmount.text 	= cityOrigin.cityResources.Power.ToString();
	}

}
