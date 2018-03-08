using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDisable : MonoBehaviour {

    public Button TheEndTurnButton;

	// Use this for initialization
	void Start ()
    {

	}

    // Note: Shit code ito pero this is it for now
    public void DisableButton()
    {
        TheEndTurnButton.interactable = false;
    }
}
