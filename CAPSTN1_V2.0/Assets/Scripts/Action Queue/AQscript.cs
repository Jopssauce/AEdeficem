using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AQscript : MonoBehaviour {

	public static AQscript instance = null;
    public Button CloseButton;
    public GameObject eventOrigin;
    // Use this for initialization

	void Awake()
	{
		if (instance == null) 
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy (this.gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}

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
