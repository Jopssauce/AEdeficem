using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventReader : MonoBehaviour
{
    public GameObject ActionQueue;

    public GameObject   eventOrigin;
    public Button       Unresolve;
    public Button       Resolve;

    private GameObject NewQueueItem;

    // Use this for initialization
    void Start()
    {
        Unresolve.onClick.AddListener(IgnoreEvent);
        Resolve.onClick.AddListener(ResolveEvent);
        
    }

    public void ResolveEvent()
    {
        eventOrigin.GetComponent<EventPopUpBase>().isResolved = true;
        Debug.Log(eventOrigin.GetComponent<EventPopUpBase>().isResolved);

        NewQueueItem = Instantiate(ActionQueue) as GameObject;
        NewQueueItem.transform.SetParent(EventManager.instance.newCanvas.transform, false);
        NewQueueItem.GetComponent<AQscript>().eventOrigin = this.eventOrigin;

        EventManager.instance.EventPanel.SetActive(false);
    }

    public void IgnoreEvent()
    {
        eventOrigin.GetComponent<EventPopUpBase>().isResolved = false;
        EventManager.instance.EventPanel.SetActive(false);
    }


}