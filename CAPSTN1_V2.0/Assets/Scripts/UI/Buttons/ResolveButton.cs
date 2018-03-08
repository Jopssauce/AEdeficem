using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolveButton : MonoBehaviour {
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
			eventOrigin.ResolveEvent();
			if ( eventManager.ResolvedEvent != null)
			{
				eventManager.ResolvedEvent.Invoke();
			}
		}
    }

}
