using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnStep : TutorialStep 
{
	public override void StartStep()
	{
		base.StartStep();
		turnManager.EndTurnEvent.AddListener(nextButtonClick);
	}
}
