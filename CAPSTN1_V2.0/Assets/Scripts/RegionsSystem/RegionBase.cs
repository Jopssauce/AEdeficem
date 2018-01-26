using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionBase : MonoBehaviour
{
    public enum RegionSpeciality
    {
        BASIC,
        WATER,
        POWER,
        FOOD
    }

    [System.Serializable]
    public class Resources
    {
        public int Water;
        public int Power;
        public int Food;
    }

    public RegionSpeciality RegionType;
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

    public void AssignRegionType()
    {
        int rand = Random.Range(0, 3);

        if (rand == 0)
        {
            this.RegionType = RegionSpeciality.BASIC;
        }
        else if (rand == 1)
        {
            this.RegionType = RegionSpeciality.WATER;
        }
        else if (rand == 2)
        {
            this.RegionType = RegionSpeciality.POWER;
        }
        else if (rand == 3)
        {
            this.RegionType = RegionSpeciality.FOOD;
        }

        AdjustResourceByType();

    }

    void AdjustResourceByType()
    {
        if (this.RegionType == RegionSpeciality.BASIC)
        {
            this.RegionResources.Water = 1;
            this.RegionResources.Power = 1;
            this.RegionResources.Food = 1;
        }
        else if (this.RegionType == RegionSpeciality.WATER)
        {
            this.RegionResources.Water = 2;
            this.RegionResources.Power = 1;
            this.RegionResources.Food = 1;
        }
        else if (this.RegionType == RegionSpeciality.POWER)
        {
            this.RegionResources.Water = 1;
            this.RegionResources.Power = 2;
            this.RegionResources.Food = 1;
        }
        else if (this.RegionType == RegionSpeciality.FOOD)
        {
            this.RegionResources.Water = 1;
            this.RegionResources.Power = 1;
            this.RegionResources.Food = 2;
        }
    }
}
