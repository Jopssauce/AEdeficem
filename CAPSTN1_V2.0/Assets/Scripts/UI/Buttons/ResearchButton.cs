using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchButton : MonoBehaviour 
{
	public int tierNum;
	public ResearchPanel researchPanel;
	public Technology.TechType type;
	public Sprite ResearchIcon;

	public void Select()
	{
		researchPanel.SelectResearch(this);
		GetComponent<Image> ().sprite = ResearchIcon;
	}


}
