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


    public ResourceManager.ResourceType RegionType;
	public float regionQuality;
	public float maxRegionQuality;
    public int RegionResourceAmount;

    public int MaxRegionResource;

    void Awake()
    {
        AssignRegionType();
    }

    // Use this for initialization
    void Start()
    {
        MaxRegionResource 	= 6;
		maxRegionQuality 	= 100f;
		regionQuality 		= 50f;
    }

    // Update is called once per frame
    void Update()
    {

    }


    /// <summary>
    /// Assigns The Region Type
    /// </summary>
    public void AssignRegionType()
    {
        int rand = Random.Range(0, 3);

        if (rand == 0)
        {
            this.RegionType = ResourceManager.ResourceType.ActionPoints;
        }
        else if (rand == 1)
        {
            this.RegionType = ResourceManager.ResourceType.Water;
        }
        else if (rand == 2)
        {
            this.RegionType = ResourceManager.ResourceType.Power;
        }
        else if (rand == 3)
        {
            this.RegionType = ResourceManager.ResourceType.Food;
        }

        //AdjustResourceByType();

    }

    public void AdjustResourceByType()
    {
        
    }
}
