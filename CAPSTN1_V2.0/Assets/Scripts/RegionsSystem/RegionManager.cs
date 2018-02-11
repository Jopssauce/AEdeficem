﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RegionManager : MonoBehaviour
{
    public List<GameObject> regionList;

    public GameObject RegionStatsCanvasPrefab;
    public GameObject RegionStatUI;

    private List<GameObject> Duplicates;
    private GameObject[] RegionHolder;
    private List<ResourceManager.ResourceType> TypeCheckList;
    private List<ResourceManager.ResourceType> MissingRegionType;

    public static RegionManager instance = null;
	void Awake()
	{
		if (instance == null) 
		{
			instance = this;	
		}
		else if (instance != this) 
		{
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);

        RegionHolder = GameObject.FindGameObjectsWithTag("Region");

        TypeCheckList       = new List<ResourceManager.ResourceType>();
        Duplicates          = new List<GameObject>();
        MissingRegionType   = new List<ResourceManager.ResourceType>();

        MakeRegionStatsCanvas();

        for (int i = 0; i < 4; i++)
        {
            MissingRegionType.Add((ResourceManager.ResourceType)i);
        }
        FixRegionTypes();
	}


    //This function assumes that the number of regions is greater than or equal to the number of resource types 
    //so having less than that will have the Unity Console an "Arguement Out of Range Error"
    void FixRegionTypes()
    {
        foreach (var item in RegionHolder)
        {
            regionList.Add(item);
        }

        foreach (var item in regionList)
        {
            //Adds existing region types and disregards duplicates
            if (!TypeCheckList.Contains(item.GetComponent<RegionBase>().regionType))
            {
                TypeCheckList.Add(item.GetComponent<RegionBase>().regionType);
            }
            else
            {
                Duplicates.Add(item);
            }
        }

        int num = 0;
        foreach (var item in MissingRegionType)
        {
            if (!TypeCheckList.Contains(item))
            {
                Duplicates[num].GetComponent<RegionBase>().regionType = item;
                Duplicates[num].GetComponent<RegionBase>().AdjustResourceByType();
                num++;
            }
        }

        regionList = regionList.OrderBy(t => t.name).ToList();
    }

    void MakeRegionStatsCanvas()
    {
        RegionStatUI = Instantiate(RegionStatsCanvasPrefab) as GameObject;
        RegionStatUI.transform.SetParent(EventManager.instance.newCanvas.transform, false);
        RegionStatUI.SetActive(false);
    }
}
