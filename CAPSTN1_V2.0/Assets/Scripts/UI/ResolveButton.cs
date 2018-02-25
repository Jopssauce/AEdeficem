using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResolveButton : MonoBehaviour, IPointerClickHandler {
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
			//eventOrigin.GetComponent<EventReader>().AddToActionQue();
			eventOrigin.ResolveEvent();
			if ( eventManager.ResolvedEvent != null)
			{
				eventManager.ResolvedEvent.Invoke();
			}
		}
    }
	#endregion
}
