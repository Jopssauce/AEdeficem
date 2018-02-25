using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResolveButton : MonoBehaviour, IPointerClickHandler {
	public EventPopUpBase eventOrigin;
	

	#region IPointerClickHandler implementation
	public void OnPointerClick(PointerEventData eventData)
    {
		if (TurnManager.instance != null)
		{
			if ( eventOrigin.ResolvedEvent != null)
			{
				eventOrigin.ResolvedEvent.Invoke();
				eventOrigin.isResolved = true;
			}
		}
    }
	#endregion
}
