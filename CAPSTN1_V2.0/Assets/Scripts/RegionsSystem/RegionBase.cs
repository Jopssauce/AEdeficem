using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionBase : MonoBehaviour
{
    [System.Serializable]
    public class Resources
    {
        public int Water;
        public int Power;
        public int Food;
    }


    public ResourceManager.ResourceType RegionType;
    public int RegionQuality;
    public Resources RegionResources;


    void Awake()
    {
        AssignRegionType();
    }

    // Use this for initialization
    void Start()
    {

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

        AdjustResourceByType();

    }

    public void AdjustResourceByType()
    {
        if (this.RegionType == ResourceManager.ResourceType.ActionPoints)
        {
            this.RegionResources.Water = 1;
            this.RegionResources.Power = 1;
            this.RegionResources.Food = 1;
        }
        else if (this.RegionType == ResourceManager.ResourceType.Water)
        {
            this.RegionResources.Water = 2;
            this.RegionResources.Power = 1;
            this.RegionResources.Food = 1;
        }
        else if (this.RegionType == ResourceManager.ResourceType.Power)
        {
            this.RegionResources.Water = 1;
            this.RegionResources.Power = 2;
            this.RegionResources.Food = 1;
        }
        else if (this.RegionType == ResourceManager.ResourceType.Food)
        {
            this.RegionResources.Water = 1;
            this.RegionResources.Power = 1;
            this.RegionResources.Food = 2;
        }
    }
}
