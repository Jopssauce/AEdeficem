using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreButton : MonoBehaviour {
	public EventPopUpBase eventOrigin;
	EventManager eventManager;
  	void Start()
    {
        if (EventManager.instance != null)
		{
			eventManager = EventManager.instance;
		}
	}
	

	public void Click()
    {
		if (TurnManager.instance != null)
		{
			eventOrigin.RefundEvent();
			if ( eventManager.IgnoredEvent != null)
			{
				eventManager.IgnoredEvent.Invoke();
			}
		}
    }

}
