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

    private GameObject  NewQueueItem;
    private Queue<GameObject> queueActions;
    // Use this for initialization
    void Start()
    {
        queueActions = new Queue<GameObject>();
        Unresolve.onClick.AddListener(IgnoreEvent);
        Resolve.onClick.AddListener(ResolveEvent);
    }

    public void ResolveEvent()
    {
        if (ResourceManager.instance.CheckResources(eventOrigin) == true)
        {
            eventOrigin.GetComponent<EventPopUpBase>().isResolved = true;
            Debug.Log(eventOrigin.GetComponent<EventPopUpBase>().isResolved);

            NewQueueItem = Instantiate(ActionQueue, new Vector3(0.0f, queueActions.Count * 386.1f, 0.0f), Quaternion.identity) as GameObject;
            NewQueueItem.transform.SetParent(EventManager.instance.newCanvas.transform, false);
            NewQueueItem.GetComponent<AQscript>().eventOrigin = this.eventOrigin;
            queueActions.Enqueue(NewQueueItem);

            EventManager.instance.EventPanel.SetActive(false);
        }
        else
        {
            Debug.Log("Not Enough Resources");
        }
    }

    public void IgnoreEvent()
    {
        eventOrigin.GetComponent<EventPopUpBase>().isResolved = false;
        EventManager.instance.EventPanel.SetActive(false);
    }


}