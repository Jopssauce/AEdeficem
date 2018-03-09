using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TurnButton : MonoBehaviour {
	public TurnManager 	turnManager;
	public EventManager eventManager;
	//public Animator 	animator;
	
	void Start()
	{
		if (TurnManager.instance != null)
		{
			turnManager = TurnManager.instance;
		}
		if (EventManager.instance != null)
		{
			eventManager = EventManager.instance;
		}
		//animator = GetComponent<Animator>();
	}
	public void OnClick()
    {
		if (TurnManager.instance != null)
		{
			//if (animator.isActiveAndEnabled == false)
			//{
				//animator.SetTrigger("Active");
				if (turnManager.EndTurnEvent != null)
				{
				turnManager.EndTurnEvent.Invoke();
				}
				turnManager.isTurnEnded = true;
			//}
			
		}
    }
}
