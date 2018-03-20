using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class hide : MonoBehaviour, IPointerDownHandler
{
	public void OnPointerDown (PointerEventData eventData)
	{
		this.transform.parent.gameObject.SetActive (false);
	}
}
