using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExitBtn : MonoBehaviour,IPointerDownHandler {

	#region IPointerDownHandler implementation
	public void OnPointerDown (PointerEventData eventData)
	{
		Destroy(this.transform.parent.transform.gameObject);
	}
	#endregion
}
