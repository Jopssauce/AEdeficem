using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DoTweenPunch : MonoBehaviour {

	public Button EndTurnButton;
    private float duration = 1.0f;

	public void OnClick()
	{
		EndTurnButton.transform.DOPunchScale (new Vector3 (-0.1f, -0.1f), duration, 10, (float)0.5f);
	}

}
