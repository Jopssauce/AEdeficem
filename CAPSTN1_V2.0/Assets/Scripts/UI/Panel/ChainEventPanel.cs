using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChainEventPanel : EventPanel 
{
	public Button longResolve;
	public Button shortResolve;


	public void LongResolveCLick()
	{
		if (TurnManager.instance != null)
		{
			eventOrigin.GetComponent<ChainEvent>().LongTermResolve();
			if ( eventManager.ResolvedEvent != null)
			{
				eventManager.ResolvedEvent.Invoke();
			}
		}
	}
	public void ShortResolveClick()
	{
		if (TurnManager.instance != null)
		{
			eventOrigin.GetComponent<ChainEvent>().ShortTermResolve();
			if ( eventManager.ResolvedEvent != null)
			{
				eventManager.ResolvedEvent.Invoke();
			}
		}
	}
	
}
