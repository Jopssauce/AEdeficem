using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventReader : MonoBehaviour
{
    public Button EventOrigin;

    public Text EventText;
    public Text EventTitle;

    public Button Unresolve;
    public Button Resolve;

    // Use this for initialization
    void Start()
    {
        Unresolve.onClick.AddListener(IgnoreEvent);
        Resolve.onClick.AddListener(ResolveEvent);
    }

    public void ResolveEvent()
    {
        EventOrigin.GetComponent<EventPopUpBase>().ResolveOnEnd = true;
        Debug.Log(EventOrigin.GetComponent<EventPopUpBase>().ResolveOnEnd);
        Destroy(this.gameObject);
    }

    public void IgnoreEvent()
    {
        EventOrigin.GetComponent<EventPopUpBase>().ResolveOnEnd = false;
        Debug.Log(EventOrigin.GetComponent<EventPopUpBase>().ResolveOnEnd);
        Destroy(this.gameObject);
    }
}
