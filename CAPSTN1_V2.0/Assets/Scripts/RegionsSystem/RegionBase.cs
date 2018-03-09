﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionBase : MonoBehaviour
{

    
	public List<EventData> 				resolvedChainEvents;
	public float                        regionQuality;
	public float                        maxRegionQuality;
    public Material                     material;
    public int                          MaxRegionResource;
    public float                        regionQualityDecay;
    private TurnManager                 turnManager;
    public CityBase                     cityOrigin;

    // Use this for initialization
    void Start()
    {
        MaxRegionResource 	= 6;
        maxRegionQuality    = 100;
        regionQualityDecay  = 0.05f;
        //regionResourceAmount = Mathf.RoundToInt( ( regionQuality / maxRegionQuality) * MaxRegionResource);
        material            = this.GetComponent<Renderer>().material;
        material.shader = Shader.Find("SFHologram/HologramShader");
        if (TurnManager.instance != null)
        {
            turnManager = TurnManager.instance;
        }
        turnManager.EndTurnEvent.AddListener(UpdateRegion);
    }

    // Update is called once per frame
    void Update()
    {
        material.SetColor("_MainColor", Color.Lerp(Color.red, Color.cyan, regionQuality / maxRegionQuality) );
    }




    public void UpdateRegion()
    {
            regionQuality 			-= regionQualityDecay * maxRegionQuality;
           // regionResourceAmount 	= Mathf.RoundToInt( (regionQuality / maxRegionQuality) * MaxRegionResource);
            material.color 			= Color.Lerp(Color.red, Color.cyan, regionQuality / maxRegionQuality);
           // if (regionResourceAmount <= 0)
            //{
           //     regionResourceAmount = 0;
           // }
            if (regionQuality > maxRegionQuality)
            {
                regionQuality = maxRegionQuality;
            }
    }

}
