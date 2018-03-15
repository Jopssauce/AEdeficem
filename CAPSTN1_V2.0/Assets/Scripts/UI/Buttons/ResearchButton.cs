using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchButton : MonoBehaviour 
{
	public int tierNum;
	public ResearchPanel researchPanel;
	public Technology.TechType type;

	public void Select()
	{
		researchPanel.SelectResearch(this);
	}


}
