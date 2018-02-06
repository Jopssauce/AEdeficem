using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventPopUpBase : MonoBehaviour
{
    public string EventTitle;
    public int TurnsBeforeFail;
    [TextArea]
    public string EventDetails;
    public bool isResolved;
    public GameObject EventCanvas;

    public GameObject RegionOrigin;

	// Use this for initialization
	void Start ()
    {
        this.GetComponent<Button>().onClick.AddListener(Click);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void Click()
    {
        EventManager.instance.EventPanel.SetActive(true);
        EventManager.instance.EventPanel.GetComponent<EventReader>().EventOrigin = this.GetComponent<Button>();
        EventManager.instance.EventPanel.transform.SetAsLastSibling();
    }
}