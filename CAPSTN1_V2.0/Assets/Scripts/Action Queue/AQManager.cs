using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AQManager : MonoBehaviour {

    public static AQManager instance = null;
    public GameObject Panel;
    public GameObject ParentPrefab;
   // public GameObject EventOrigin;
   // public GameObject InstantiatedPrefab;

    //private UIActionElement uiAction;
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

    void Start()
    {
        
    }

    public void RemoveActionUI()
    {
        Panel.SetActive(false);
        foreach (Transform child in ParentPrefab.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
