using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LongResolveButton : MonoBehaviour {
	public ChainEvent eventOrigin;
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
			eventOrigin.LongTermResolve();
			if ( eventManager.ResolvedEvent != null)
			{
				eventManager.ResolvedEvent.Invoke();
			}
		}
	}

}
