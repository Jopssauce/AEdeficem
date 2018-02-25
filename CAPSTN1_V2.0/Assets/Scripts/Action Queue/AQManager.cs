using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AQManager : MonoBehaviour {

    public static AQManager instance = null;
    public GameObject Panel;
    public GameObject ParentPrefab;

	private TurnManager eventResolve;

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
		if (TurnManager.instance != null) 
		{
			eventResolve = TurnManager.instance;
		}


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
