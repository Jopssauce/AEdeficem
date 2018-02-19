using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AQManager : MonoBehaviour {

    public static AQManager instance = null;
    public GameObject EventOrigin;

    private UIActionElement uiAction;
    // Use this for initialization

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void RemoveActionUI()
    {
        
    }
}
