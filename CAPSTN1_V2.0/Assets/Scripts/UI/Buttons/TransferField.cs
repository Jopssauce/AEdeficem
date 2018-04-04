using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransferField : MonoBehaviour 
{
	public TransferPanel transferPanel;
	public Text cityToTransferName;
	public CityBase cityTarget;

	public Toggle toggle;
	public InputField waterInput;
	public InputField foodInput;
	public InputField powerInput;

	


	public void toggleButton()
	{
		if (toggle.isOn == false)
		{
			if (isEnoughRes() == false)
			{
				toggle.isOn = false;
			}
			else if(isEnoughRes() == true)
			{
				transferPanel.SpawnUnit(cityTarget, int.Parse(waterInput.text), int.Parse(foodInput.text),  int.Parse(powerInput.text));
			}
		}
	
		
	}

	  public bool isEnoughRes()
	{
		FindObjectOfType<AudioManager> ().Play ("Generic");
		if (transferPanel.cityOrigin.cityResources.Water < int.Parse(waterInput.text) || transferPanel.cityOrigin.cityResources.Food < int.Parse(foodInput.text) 
		 || transferPanel.cityOrigin.cityResources.Power < int.Parse(powerInput.text) )
		{
			return false;
		}
		else
		{
			return true;
		}
		
		
	}
}
