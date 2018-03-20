using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Exit : MonoBehaviour
{
	public void Click()
	{
		// note only works on build not editor
		Application.Quit ();
	}
}
