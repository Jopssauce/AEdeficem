using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DoTweenPunch : MonoBehaviour {

	public Button EndTurnButton;
    private float duration = 1.0f;
	private Animator anim;

	void Start()
	{
		anim = GetComponent<Animator> ();
	}

	public void OnClick()
	{
		EndTurnButton.transform.DOPunchScale (new Vector3 (-0.1f, -0.1f), duration, 10, (float)0.5f);
	}
		
	public void MouseOver()
	{
		anim.SetBool ("IsMouseHover", true);
	}

	public void MouseExit()
	{
		anim.SetBool ("IsMouseHover", false);
	}
}
