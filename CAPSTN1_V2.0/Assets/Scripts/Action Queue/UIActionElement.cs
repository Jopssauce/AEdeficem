using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIActionElement : MonoBehaviour
{

    public EventPopUpBase eventOrigin;
    public Button CloseButton;
    private EventManager eventManagerInstance;

    public void RemoveAction()
    {
        Destroy(this.gameObject);
    }
}
