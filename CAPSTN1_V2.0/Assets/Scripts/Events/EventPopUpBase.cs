using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventPopUpBase : MonoBehaviour
{
    public EventData   eventData;
    public GameObject  regionOrigin;
    public int         turnsLeft;
    public bool        isResolved;
	void Start ()
    {
        isResolved = false;
        
        this.GetComponent<Button>().onClick.AddListener(Click);
		this.GetComponent<BindToRegion> ().regionOrigin = regionOrigin;
	}
	
    void Update()
    {
        if (isResolved == true)
        {
            ColorBlock cb = this.GetComponent<Button>().colors;
            cb.normalColor = Color.green;
            this.GetComponent<Button>().colors = cb;
        }
        if (isResolved == false)
        {
            ColorBlock cb = this.GetComponent<Button>().colors;
            cb.normalColor = Color.red;
            this.GetComponent<Button>().colors = cb;
        }
    }

    void Click()
    {   
        EventManager.instance.EventPanel.GetComponent<EventReader>().eventOrigin        = this.gameObject;
        EventManager.instance.EventPanel.GetComponent<EventTextDisplay>().eventOrigin   = this.gameObject;
        EventManager.instance.EventPanel.GetComponent<DisplayResourceCost>().eventOrigin   = this.gameObject;
        EventManager.instance.EventPanel.SetActive(true);
        EventManager.instance.EventPanel.transform.SetAsLastSibling();
    }
	
}