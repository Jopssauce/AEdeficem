using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TransferPanel : MonoBehaviour 
{
	public RegionBase regionOrigin;

	public CityBase   	cityOrigin;
	public CityBase		cityTarget;

	public List<RegionBase> regionListCopy;
	public List<string> cityName;

	public Text regionOriginName;

	public Text waterAmount;
	public Text	foodAmount;
	public Text powerAmount;

	public List<TransferField> transferFields;

	public Dropdown dropdown;
	public Button exitButton;

	public GameObject cityDropdownContentPrefab;
	public GameObject notificationPanel;
	
	RegionManager regionManager;
	ResourceManager resourceManager;
	TurnManager turnManager;
	TutorialManager tutorialManager;
	
	public int waterSum;
	public int foodSum;
	public int powerSum;

	void Start()
	{
		regionOrigin = cityOrigin.regionOrigin;
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

		regionOriginName.text = regionOrigin.cityOrigin.name;
		foreach (var item in regionListCopy)
		{
			cityName.Add(item.cityOrigin.name);
		}

		
		for (int i = 0; i <= regionListCopy.Count-1; i++)
		{
			transferFields[i].transferPanel = this;
			transferFields[i].cityToTransferName.text = regionListCopy[i].cityOrigin.name;
			transferFields[i].cityTarget = regionListCopy[i].cityOrigin;
		}

		dropdown.AddOptions(cityName);
		SetUIText();
		
	}


	public void SpawnUnit()
    {
		waterSum = 0;
		foodSum = 0;
		powerSum = 0;

		foreach (var item in transferFields)
		{
			waterSum += int.Parse(item.waterInput.text);
			foodSum += int.Parse(item.foodInput.text);
			powerSum += int.Parse(item.powerInput.text);
		}

		if (isEnoughRes() && transferFields.Any(field => field.toggle.isOn == true))
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
			
			foreach (var item in transferFields)
			{
				if (item.toggle.isOn == true)
				{
					cityOrigin.SpawnResourceSender(item.cityTarget, int.Parse(item.waterInput.text), int.Parse(item.foodInput.text), int.Parse(item.powerInput.text));
					
					SetUIText();
				}
				
			}
        	resourceManager.DeductResource(ResourceManager.ResourceType.ActionPoints, 2);
			Destroy (this.gameObject);
		}
		if(!isEnoughRes())
		{
			notificationPanel.GetComponent<NotificationPanel>().text.text = "Not Enough Resources";
			notificationPanel.gameObject.SetActive(true);
		}
		else if (transferFields.All(field => field.toggle.isOn == false))
		{
			notificationPanel.GetComponent<NotificationPanel>().text.text = "No City Selected";
			notificationPanel.gameObject.SetActive(true);
		}
			   
			FindObjectOfType<AudioManager> ().Play ("Generic");   
    }


	public void exitClick()
	{
		Destroy(this.gameObject);
	}

	public bool isEnoughRes()
	{
        CityBase cityOrigin = regionOrigin.cityOrigin;
		FindObjectOfType<AudioManager> ().Play ("Generic");
		if (cityOrigin.cityResources.Water < waterSum || cityOrigin.cityResources.Food < foodSum 
		 || cityOrigin.cityResources.Power < powerSum )
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
