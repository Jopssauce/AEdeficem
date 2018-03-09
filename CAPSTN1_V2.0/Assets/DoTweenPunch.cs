using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DoTweenPunch : MonoBehaviour {

	public Button EndTurnButton;

	public void OnClick()
	{
		EndTurnButton.transform.DOPunchScale (new Vector3 (-0.1f, -0.1f), 1.0f, 10, (float)0.5f);
	}
}
