﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class RegionManager : MonoBehaviour
{
    public List<GameObject> regionList;

    public GameObject RegionStatsCanvasPrefab;
    public GameObject RegionStatUI;

    private List<GameObject> Duplicates;
    private GameObject[] RegionHolder;
    private List<ResourceManager.ResourceType> TypeCheckList;
    private List<ResourceManager.ResourceType> MissingRegionType;

    TurnManager turnManager;

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

    void Start()
    {
        if (TurnManager.instance != null)
        {
            turnManager = TurnManager.instance;
        }
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

    public void UpdateRegion()
    {
        foreach (var region in regionList)
        {
            RegionBase regionBase 				= region.GetComponent<RegionBase>();
            regionBase.regionQuality 			-= regionBase.regionQualityDecay * regionBase.maxRegionQuality;
            regionBase.regionResourceAmount 	= Mathf.RoundToInt( (regionBase.regionQuality / regionBase.maxRegionQuality) * regionBase.MaxRegionResource);
            regionBase.material.color 			= Color.Lerp(Color.red, Color.cyan, regionBase.regionQuality / regionBase.maxRegionQuality);
            if (regionBase.regionResourceAmount <= 0)
            {
                regionBase.regionResourceAmount = 0;
            }
            if (regionBase.regionQuality > regionBase.maxRegionQuality)
            {
                regionBase.regionQuality = regionBase.maxRegionQuality;
            }
        }

        bool isVictory;
        if (turnManager.currentTurn >= 50)
        {
        if (regionList.All(region => region.GetComponent<RegionBase>().regionQuality >= 90))
            {
                isVictory = true;
                //Victory Scene
                PlayerPrefs.SetString("isVictory", isVictory.ToString());
                SceneManager.LoadScene("Victory Scene");
            }
        }
        
        if (regionList.All(region => region.GetComponent<RegionBase>().regionQuality <= 0))
        {
            isVictory = false;
            //Defeat Scene
            PlayerPrefs.SetString("isVictory", isVictory.ToString());
            SceneManager.LoadScene("Victory Scene");
        }
    }
}
