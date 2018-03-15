using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetResearchTiers : MonoBehaviour {

	ResearchManager researchManager;
	void Start()
	{
		if (ResearchManager.instance != null)
		{
			researchManager = ResearchManager.instance;
		}
	}
	public void Click()
	{
		researchManager.tierProgress.disasterPrepTier = 4;
		researchManager.tierProgress.resourceProdTier = 4;
		researchManager.tierProgress.transportEffTier = 4;
		researchManager.tierProgress.regionalPlanTier = 4;
	}
}
