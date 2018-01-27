﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour {

	public static EventManager instance = null;

    public Button prefab;
    public Canvas newCanvas;

    public RegionManager RegionManagerInstance;

    void Awake()
	{
        newCanvas = Canvas.FindObjectOfType<Canvas>();

		if (instance == null) 
		{
			instance = this;	
		}
		else if (instance != this) 
		{
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}

    void Start()
    {
        Invoke("SpawnEvent",0.1f);
    }

    public void SpawnEvent()
    {
        RegionManagerInstance = RegionManager.instance;

        Button newButton = Instantiate(prefab) as Button;
        newButton.transform.SetParent(newCanvas.transform, false);

        int num = Random.Range(0 , RegionManagerInstance.Region.Count - 1);

        Debug.Log(RegionManagerInstance.Region[num].transform.position);

        Vector2 point = Camera.main.WorldToScreenPoint(RandomPointInBox(RegionManagerInstance.Region[num].transform.position, RegionManagerInstance.Region[num].transform.localScale));

        newButton.transform.position = point;

    }

    private Vector2 RandomPointInBox(Vector2 center, Vector2 size)
    {
        return center + new Vector2((Random.value - 0.5f) * size.x,(Random.value - 0.5f) * size.y);
    }
}