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
        GameObject newButton = Instantiate(EventCanvas) as GameObject;
        newButton.GetComponent<EventReader>().EventOrigin = this.GetComponent<Button>();
        newButton.transform.SetParent(EventManager.instance.newCanvas.transform, false);
    }
}