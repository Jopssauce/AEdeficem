using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventPopUpBase : MonoBehaviour
{
    public int          turnsLeft;
    public bool         isResolved;

    public EventData    eventData;
    public EventsList   eventsList;
    public GameObject   regionOrigin;

	void Start ()
    {
        this.GetComponent<Button>().onClick.AddListener(Click);
		this.GetComponent<BindToRegion> ().regionOrigin = regionOrigin;
        eventData = eventsList.eventDataList[Random.Range(0, eventsList.eventDataList.Count)];
	}
	
    void Click()
    {   
        EventManager.instance.EventPanel.GetComponent<EventReader>().eventOrigin        = this.gameObject;
        EventManager.instance.EventPanel.GetComponent<EventTextDisplay>().eventOrigin   = this.gameObject;
        EventManager.instance.EventPanel.SetActive(true);
        EventManager.instance.EventPanel.transform.SetAsLastSibling();
    }
	
}