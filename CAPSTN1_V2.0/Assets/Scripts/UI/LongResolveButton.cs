using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LongResolveButton : MonoBehaviour, IPointerClickHandler {
	public ChainEvent eventOrigin;
	EventManager eventManager;

	void Start()
	{
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
			//eventOrigin.GetComponent<EventReader>().AddToActionQue();
			eventOrigin.LongTermResolve();
			if ( eventManager.ResolvedEvent != null)
			{
				eventManager.ResolvedEvent.Invoke();
			}
		}
	}
	#endregion
}
