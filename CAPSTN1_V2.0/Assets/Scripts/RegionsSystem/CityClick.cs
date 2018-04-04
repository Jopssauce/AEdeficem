using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CityClick : MonoBehaviour {
	public CityBase cityOrigin;
	public GameObject BlockPanel;

	private GameObject blockPanel;	

	public ParticleSystem cityParticle;

	public TutorialManager tutorialManager;
	void Start()
	{
		cityOrigin = GetComponent<CityBase>();
	}

	
	void OnMouseOver()
	{
		if (!EventSystem.current.IsPointerOverGameObject () && !(tutorialManager.currentTutorialStepPanel is SendUnitStep) && !(tutorialManager.currentTutorialStepPanel is SendUnitStep2) )
		{
			cityParticle.gameObject.SetActive(true);
			if (Input.GetMouseButtonDown (0))
			{
				if (cityOrigin.tutorialManager != null)
				{
					if (cityOrigin.tutorialManager.currentTutorialStepPanel != null)
					{
						if (cityOrigin.tutorialManager.currentTutorialStepPanel.GetComponent<CitiesStep>())
						{
							cityOrigin.tutorialManager.currentTutorialStepPanel.GetComponent<CitiesStep>().isStepDone = true;
							cityOrigin.tutorialManager.currentTutorialStepPanel.GetComponent<CitiesStep>().nextButtonClick();
						}
					}           
				}
				Debug.Log (cityOrigin.name);
				cityOrigin.SpawnTransferPanel ();
				FindObjectOfType<AudioManager> ().Play ("Generic");
			}
		}
	}
	void OnMouseExit()
	{	
		if (!EventSystem.current.IsPointerOverGameObject())
		{
			if (cityOrigin.transferPanel == null)
			{
				cityParticle.gameObject.SetActive(false);
			}
		}
		
		
	}
	
}
