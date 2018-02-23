using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveCameraToEvent : MonoBehaviour, IPointerClickHandler {

	public Vector3 		eventWorldPos;

	#region IPointerClickHandler implementation
	public void OnPointerClick(PointerEventData eventData)
    {
		Debug.Log("Clicked");
		Camera.main.transform.position = eventWorldPos;
    }
	#endregion*/
}

