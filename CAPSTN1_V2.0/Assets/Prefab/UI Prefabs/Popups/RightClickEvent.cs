using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightClickEvent : MonoBehaviour, IPointerClickHandler {
	
	public GameObject	rightClickPanel { get; set;}
	public GameObject	RightClickPanelPrefab;

	// Update is called once per frame
	void Update () 
	{
		
	}
		
	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			
		}
	}
}
