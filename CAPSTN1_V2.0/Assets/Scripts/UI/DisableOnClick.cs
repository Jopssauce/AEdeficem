using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisableOnClick : MonoBehaviour, IPointerDownHandler
{

	#region IPointerDownHandler implementation
	public void OnPointerDown (PointerEventData eventData)
	{
		this.transform.parent.transform.gameObject.SetActive(false);
	}
	#endregion
}
