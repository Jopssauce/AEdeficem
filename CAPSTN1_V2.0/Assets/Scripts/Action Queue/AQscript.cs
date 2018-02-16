using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AQscript : MonoBehaviour {

    public Button CloseButton;
    public GameObject eventOrigin;
    // Use this for initialization
    void Start() 
	{
        CloseButton.onClick.AddListener(RemoveFromQueue);
    }

    public void RemoveFromQueue()
    {
        eventOrigin.GetComponent<EventPopUpBase>().isResolved = false;
        Destroy(this.gameObject);
    }
}
