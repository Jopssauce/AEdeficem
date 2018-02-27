using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EventContent : MonoBehaviour, IPointerClickHandler  {
	public GameObject 	eventOrigin;
	public GameObject	particleEffect;
	public Text 		eventTitle;
	public int 			turnsLeft;
	public Vector3 		eventWorldPos;
	public Vector3		eventPosToCamera;
	// Use this for initialization
	void Start () 
	{
		eventTitle.text = eventOrigin.GetComponent<EventPopUpBase>().eventData.eventName;
		this.GetComponent<DisplayResourceCost>().eventOrigin = this.eventOrigin;
	}
	void Update()
	{
		if (eventOrigin != null)
		{
			turnsLeft = eventOrigin.GetComponent<EventPopUpBase>().turnsLeft;
			eventWorldPos.x = eventOrigin.GetComponent<EventPopUpBase>().eventWorldPos.x;
			eventWorldPos.y = eventOrigin.GetComponent<EventPopUpBase>().eventWorldPos.y + 0.5f;
			eventWorldPos.z = eventOrigin.GetComponent<EventPopUpBase>().eventWorldPos.z;
			
			eventPosToCamera.x = eventOrigin.GetComponent<EventPopUpBase>().eventWorldPos.x;
			eventPosToCamera.y = Camera.main.transform.position.y;
			eventPosToCamera.z = eventOrigin.GetComponent<EventPopUpBase>().eventWorldPos.z - 3.5f;
		}

		if (turnsLeft <= 0)
		{
			Destroy(this.gameObject);
		}
	}
	#region IPointerClickHandler implementation
	public void OnPointerClick(PointerEventData eventData)
    {
		Debug.Log("Clicked");
		Instantiate(particleEffect, eventWorldPos, particleEffect.transform.rotation);
		Camera.main.transform.position = eventPosToCamera;
    }
	#endregion
}
