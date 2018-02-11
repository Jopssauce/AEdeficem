using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventPopUpBase : MonoBehaviour
{
    public int turnsLeft;
    public bool isResolved;
    public GameObject EventCanvas;

    public GameObject regionOrigin;

	void Start ()
    {
        this.GetComponent<Button>().onClick.AddListener(Click);
		this.GetComponent<BindToRegion> ().regionOrigin = regionOrigin;
	}
	
    void Click()
    {
        EventManager.instance.EventPanel.SetActive(true);
        EventManager.instance.EventPanel.GetComponent<EventReader>().EventOrigin = this.GetComponent<Button>();
        EventManager.instance.EventPanel.transform.SetAsLastSibling();
    }
	
}