using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour 
{
	public GameObject HoverTip;
	public Text HoverTipInfo;
	public static bool IsHover = false;

	private GameObject hoverTip;

	void Update()
	{
		if(hoverTip != null)
			hoverTip.transform.position = Input.mousePosition + new Vector3 (10.0f, 10.0f, 0.0f);
	}

	public void HoverMouse()
	{
		if (IsHover == false) 
		{
			HoverTipInfo.text = "SOme Text";
			IsHover = true;
			hoverTip = Instantiate (HoverTip) as GameObject;
			hoverTip.transform.SetParent (GameObject.FindGameObjectWithTag ("Main UI").transform, false);
			hoverTip.transform.position = Input.mousePosition + new Vector3 (10.0f, 10.0f, 0.0f);
		}
	}

	public void ExitMouse()
	{
		if (IsHover == true)
		{
			IsHover = false;
		}
	}
}
