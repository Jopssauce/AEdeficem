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
    public bool ResolveOnEnd;
    public Canvas EventCanvas;

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
        Canvas newButton = Instantiate(EventCanvas) as Canvas;
        newButton.GetComponent<EventReader>().EventOrigin = this.GetComponent<Button>();

        newButton.GetComponent<EventReader>().EventTitle.text = EventTitle;
        newButton.GetComponent<EventReader>().EventText.text = EventDetails;
    }
}