﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour 
{
	public Technology technology;
	public CityBase   cityBase;
	public TurnManager turnManager;
	public ResearchManager researchManager;

	public virtual void Start()
	{
		if (TurnManager.instance != null)
		{
			turnManager = TurnManager.instance;
		}
		if (ResearchManager.instance != null)
		{
			researchManager = ResearchManager.instance;
		}
		turnManager.EndTurnEvent.AddListener(DoEffect);
		cityBase = GetComponent<CityBase>();
	}

	public virtual void UpgradeEffect()
	{
		//Debug.Log("Effect");
	}

	public virtual void DoEffect()
	{
		//if (technology.isUnlocked)
		//{
			
			UpgradeEffect();
		//}
	}

}
