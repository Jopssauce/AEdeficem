﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendUnitStep : TutorialStep 
{
	public override void nextButtonClick()
	{
		if (isStepDone == true)
		{
			tutorialUI.NextStep.Invoke();
		}
	}
	
}
