using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionBase : MonoBehaviour
{

    public List<GameObject> spawnAreas;
	public List<EventData> 				resolvedChainEvents;
	public float                        regionQuality;
	public float                        maxRegionQuality;
    public Material                     material;
    public int                          MaxRegionResource;
    public float                        regionQualityDecay;
    private TurnManager                 turnManager;
    public CityBase                     cityOrigin;
    public int                          maxEvents;
    public int                          regionDecayTimer;
    public int                          currentRegionDecayTimer;
    // Use this for initialization
    void Start()
    {
        maxEvents = 0;
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
        currentRegionDecayTimer--;
        if (currentRegionDecayTimer <= 0)
        {
            regionQuality -= regionQualityDecay * maxRegionQuality;
            currentRegionDecayTimer = regionDecayTimer;
        }
            

            material.color 			= Color.Lerp(Color.red, Color.cyan, regionQuality / maxRegionQuality);

            if (regionQuality > maxRegionQuality)
            {
                regionQuality = maxRegionQuality;
            }
    }

}
