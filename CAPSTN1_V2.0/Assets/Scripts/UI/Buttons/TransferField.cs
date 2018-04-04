using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransferField : MonoBehaviour 
{
	public TransferPanel transferPanel;
	public CityBase cityTarget;

	public Text cityToTransferName;
	public Toggle toggle;
	public InputField waterInput;
	public InputField foodInput;
	public InputField powerInput;

	
	

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
