using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIActionElement : MonoBehaviour {

    public GameObject eventOrigin;
    public Button CloseButton;

    public void RemoveAction()
	{
        eventOrigin.GetComponent<EventPopUpBase>().isResolved = false;
		Destroy (this.gameObject);
	}
}
