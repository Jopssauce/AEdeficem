using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResearchTabs : MonoBehaviour, IPointerClickHandler {

    public void ShowTab()
    {
		this.transform.parent.SetAsLastSibling ();
    }

	#region IPointerDownHandler implementation
	public void OnPointerClick (PointerEventData eventData)
	{
		ShowTab ();
	}
	#endregion
}
