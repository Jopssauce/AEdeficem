using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventReader : MonoBehaviour
{
    public GameObject ActionQueue;

    public Button EventOrigin;
    public Button Unresolve;
    public Button Resolve;

    private GameObject NewQueueItem;
	private Queue<string> details;

    // Use this for initialization
    void Start()
    {
		details = new Queue<string> ();
        Unresolve.onClick.AddListener(IgnoreEvent);
        Resolve.onClick.AddListener(ResolveEvent);
    }

    public void ResolveEvent()
    {
        EventOrigin.GetComponent<EventPopUpBase>().isResolved = true;
        Debug.Log(EventOrigin.GetComponent<EventPopUpBase>().isResolved);

        NewQueueItem = Instantiate(ActionQueue) as GameObject;
        NewQueueItem.transform.SetParent(EventManager.instance.newCanvas.transform, false);
        NewQueueItem.GetComponent<AQscript>().EventOrigin = this.EventOrigin;

        EventManager.instance.EventPanel.SetActive(false);
    }

    public void IgnoreEvent()
    {
        EventOrigin.GetComponent<EventPopUpBase>().isResolved = false;
        EventManager.instance.EventPanel.SetActive(false);
    }


}