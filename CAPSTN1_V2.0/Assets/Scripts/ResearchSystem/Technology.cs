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

	public enum TechType
    {
        Disaster,
        Resource,
        Transport,
        Regional
    }
	public TechTier techTier;
	public Technology.TechType type;
	public bool isUnlocked;
	public bool isResearching;

	public int turnsLeft;

	public string techName;
	[TextArea]
	public string techDescription;

	public CityBase cityBase;
	public ResearchManager researchManager;
	public RegionManager   regionManager;
	public TurnManager 		turnManager;

	public Texture Thumbnail;

	public void Awake()
	{
		if (ResearchManager.instance != null)
		{
			researchManager = ResearchManager.instance;
		}
		if (RegionManager.instance != null)
		{
			regionManager = RegionManager.instance;
		}
		if (TurnManager.instance != null)
		{
			turnManager = TurnManager.instance;
		}
		turnManager.EndTurnEvent.AddListener(ResearchTech);
	}


	public virtual void ResearchTech()
	{
		if (isResearching == true && turnsLeft > 0)
		{
			turnsLeft--;
		}
		if (turnsLeft <= 0 && isResearching == true)
		{
			isResearching = false;
			isUnlocked = true;
			//researchManager.progressResearchTier.Invoke(Technology.TechType.Disaster);
			researchManager.tierProgress.disasterPrepTier += 1;
			researchManager.ResearchFinished.Invoke();
			researchManager.unlockedTech.Add(Instantiate(this));
			researchManager.selectedResearch = null;
		}
	}

}
