using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ResearchTabs : MonoBehaviour, IPointerClickHandler {

	public RawImage ThePanel;
	public Texture Thumnails;

	void Start()
	{
		ShowTab ();
	}

    public void ShowTab()
    {
		ThePanel.texture = Thumnails;
		this.transform.parent.SetSiblingIndex (10);
    }

	#region IPointerDownHandler implementation
	public void OnPointerClick (PointerEventData eventData)
	{
		ShowTab ();
		FindObjectOfType<AudioManager> ().Play ("Generic");
	}
	#endregion
}
