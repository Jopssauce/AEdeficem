using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Technology : ScriptableObject 
{
	public enum TechTier
	{
		Tier1,
		Tier2,
		Tier3,
		Tier4
	}
	public TechTier techTier;
	public ResearchManager.ResearchTypes type;
	public bool isUnlocked;
	public bool isResearching;

	public int turnsLeft;

	public string techName;

	public CityBase cityBase;
	public ResearchManager researchManager;

	public void Awake()
	{
		if (ResearchManager.instance != null)
		{
			researchManager = ResearchManager.instance;
		}
	}

	public void ResearchTech()
	{
		if (isResearching == true && turnsLeft > 0)
		{
			turnsLeft--;
		}
		if (turnsLeft <= 0 && isResearching == true)
		{
			isResearching = false;
			isUnlocked = true;
			researchManager.progressResearchTier.Invoke(ResearchManager.ResearchTypes.Disaster);
			researchManager.ResearchFinished.Invoke();
			researchManager.unlockedTech.Add(Instantiate(this));
			researchManager.selectedResearch = null;
		}
	}

	public virtual void TechEffect()
	{
		
	}
}
