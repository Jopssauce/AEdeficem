using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AQscript : MonoBehaviour {

    public Button CloseButton;
    public GameObject eventOrigin;
    // Use this for initialization
    void Start() {
        CloseButton.onClick.AddListener(RemoveFromQueue);
    }

    void RemoveFromQueue()
    {
        eventOrigin.GetComponent<EventPopUpBase>().isResolved = false;
        Destroy(this.gameObject);
    }
}
