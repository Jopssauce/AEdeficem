using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventReader : MonoBehaviour
{
    public GameObject ActionQueue;

    public Text EventText;
    public Text EventTitle;

    public Button EventOrigin;
    public Button Unresolve;
    public Button Resolve;

	private Queue<string> details;

    private EventManager call;

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

        GameObject NewActionQueue = Instantiate(ActionQueue) as GameObject;
        NewActionQueue.transform.SetParent(EventManager.instance.newCanvas.transform, false);
        NewActionQueue.GetComponent<AQscript>().EventOrigin = this.EventOrigin;

        Destroy(this.gameObject);
    }

    public void IgnoreEvent()
    {
        EventOrigin.GetComponent<EventPopUpBase>().isResolved = false;
        //Debug.Log(EventOrigin.GetComponent<EventPopUpBase>().isResolved);
        Destroy(this.gameObject);
    }

	public void StartText()
	{
		
	}
}