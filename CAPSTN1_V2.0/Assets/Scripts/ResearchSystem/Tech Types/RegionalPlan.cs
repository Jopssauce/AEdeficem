using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "RegionalPlan", menuName = "Technology/RegionalPlan")]
public class RegionalPlan : Technology 
{
    public override void ResearchTech()
	{
		if (isResearching == true && turnsLeft > 0)
		{
			turnsLeft--;
		}
		if (turnsLeft <= 0 && isResearching == true)
		{
			isResearching = false;
			isUnlocked = true;
			researchManager.progressResearchTier.Invoke(Technology.TechType.Regional);
			researchManager.ResearchFinished.Invoke();
			researchManager.unlockedTech.Add(Instantiate(this));
			researchManager.selectedResearch = null;
		}
	}
}
