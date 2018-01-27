﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionManager : MonoBehaviour
{
    public List<GameObject> Region;


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
	}

    void Start()
    {
        RegionHolder = GameObject.FindGameObjectsWithTag("Region");

        TypeCheckList = new List<ResourceManager.ResourceType>();
        Duplicates = new List<GameObject>();
        MissingRegionType = new List<ResourceManager.ResourceType>();

        

        for (int i = 0; i < 4; i++)
        {
            MissingRegionType.Add((ResourceManager.ResourceType)i);
        }
        FixRegionTypes();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckRegionQuality()
    {

    }

    void FixRegionTypes()
    {
        foreach (var item in RegionHolder)
        {
            Region.Add(item);
        }

        foreach (var item in Region)
        {
            //Adds existing region types and disregards duplicates
            if (!TypeCheckList.Contains(item.GetComponent<RegionBase>().RegionType))
            {
                TypeCheckList.Add(item.GetComponent<RegionBase>().RegionType);
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
                Duplicates[num].GetComponent<RegionBase>().RegionType = item;
                Duplicates[num].GetComponent<RegionBase>().AdjustResourceByType();
                num++;
            }
        }
    }
}