using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurnButton : MonoBehaviour, IPointerClickHandler {
	public TurnManager 	turnManager;
	public EventManager eventManager;
	
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
	}

	#region IPointerClickHandler implementation
	public void OnPointerClick(PointerEventData eventData)
    {
		if (TurnManager.instance != null)
		{
			if ( turnManager.EndTurnEvent != null)
			{
				turnManager.EndTurnEvent.Invoke();
			}
			turnManager.isTurnEnded = true;
			//turnManager.AdvanceTurn();
			//Debug.Log("Turn Button Clicked");
		}
        //throw new System.NotImplementedException();
    }
	#endregion
}
