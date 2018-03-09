using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionBase : MonoBehaviour
{
    [System.Serializable]
    public class Resources
    {
        public int Ap;
        public int Water;
        public int Power;
        public int Food;
    }

    
	public List<EventData> 				resolvedChainEvents;
	public float                        regionQuality;
	public float                        maxRegionQuality;
    public int                          regionResourceAmount;
    public Material                     material;
    public int                          MaxRegionResource;
    public float                        regionQualityDecay;
    public ResourceManager.ResourceType regionType;
    private TurnManager                 turnManager;

    // Use this for initialization
    void Start()
    {
        MaxRegionResource 	= 6;
        maxRegionQuality    = 100;
        regionQualityDecay  = 0.05f;
        regionResourceAmount = Mathf.RoundToInt( ( regionQuality / maxRegionQuality) * MaxRegionResource);
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


    /// <summary>
    /// Assigns The Region Type
    /// </summary>
    public void AssignRegionType()
    {
        int rand = Random.Range(0, 3);

        if (rand == 0)
        {
            this.regionType = ResourceManager.ResourceType.ActionPoints;
        }
        else if (rand == 1)
        {
            this.regionType = ResourceManager.ResourceType.Water;
        }
        else if (rand == 2)
        {
            this.regionType = ResourceManager.ResourceType.Power;
        }
        else if (rand == 3)
        {
            this.regionType = ResourceManager.ResourceType.Food;
        }
    }

    public void UpdateRegion()
    {
            regionQuality 			-= regionQualityDecay * maxRegionQuality;
            regionResourceAmount 	= Mathf.RoundToInt( (regionQuality / maxRegionQuality) * MaxRegionResource);
            material.color 			= Color.Lerp(Color.red, Color.cyan, regionQuality / maxRegionQuality);
            if (regionResourceAmount <= 0)
            {
                regionResourceAmount = 0;
            }
            if (regionQuality > maxRegionQuality)
            {
                regionQuality = maxRegionQuality;
            }
    }

}
