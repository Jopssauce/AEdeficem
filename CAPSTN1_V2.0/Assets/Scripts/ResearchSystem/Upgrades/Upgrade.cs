using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour 
{
	public Technology technology;
	public CityBase   cityBase;

	public virtual void UpgradeEffect()
	{

	}

	public virtual void DoEffect()
	{
		if (technology.isUnlocked)
		{
			UpgradeEffect();
		}
	}

}
