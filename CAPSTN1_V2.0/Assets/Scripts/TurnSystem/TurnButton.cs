using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurnButton : MonoBehaviour, IPointerClickHandler {
	public TurnManager 	turnManager;
	public EventManager eventManager;
	public Animator 	animator;
	
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
		animator = GetComponent<Animator>();
	}

	#region IPointerClickHandler implementation
	public void OnPointerClick(PointerEventData eventData)
    {
		if (TurnManager.instance != null)
		{
			//if (animator.isActiveAndEnabled == false)
			//{
				animator.SetTrigger("Active");
				if (turnManager.EndTurnEvent != null)
				{
				turnManager.EndTurnEvent.Invoke();
				}
				turnManager.isTurnEnded = true;
			//}
			
		}
    }
	#endregion
}
