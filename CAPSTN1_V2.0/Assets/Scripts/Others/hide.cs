using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class hide : MonoBehaviour, IPointerClickHandler
{
	public void OnPointerClick (PointerEventData eventData)
	{
		FindObjectOfType<AudioManager> ().Play ("Generic");
		this.transform.parent.gameObject.SetActive (false);
	}
}
