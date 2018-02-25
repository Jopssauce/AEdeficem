using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IgnoreButton : MonoBehaviour, IPointerClickHandler {
	public EventPopUpBase eventOrigin;
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
			
			if ( eventManager.IgnoredEvent != null)
			{
				eventManager.IgnoredEvent.Invoke();
			}
			eventOrigin.IgnoreEvent();
		}
    }
	#endregion
}
