﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour {
	public EventPopUpBase eventOrigin;
	public void Click()
	{
		eventOrigin.ExitEvent();
	}
}