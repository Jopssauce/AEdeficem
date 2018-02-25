using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IgnoreButton : MonoBehaviour, IPointerClickHandler {
	public EventPopUpBase eventOrigin;
	

	#region IPointerClickHandler implementation
	public void OnPointerClick(PointerEventData eventData)
    {
		if (TurnManager.instance != null)
		{
			if ( eventOrigin.IgnoredEvent != null)
			{
				eventOrigin.IgnoredEvent.Invoke();
				eventOrigin.isResolved = false;
			}
		}
    }
	#endregion
}
