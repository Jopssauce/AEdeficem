using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AQscript : MonoBehaviour {

    public Button CloseButton;
    public Button EventOrigin;
    // Use this for initialization
    void Start() {
        CloseButton.onClick.AddListener(RemoveFromQueue);
    }

    void RemoveFromQueue()
    {
        EventOrigin.GetComponent<EventPopUpBase>().isResolved = false;
        Destroy(this.gameObject);
    }
}
