using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionManager : MonoBehaviour
{
    public List<GameObject> Region;

    private GameObject[] RegionHolder;
    private List<RegionBase.RegionSpeciality> TypeCheckList;

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

        TypeCheckList = new List<RegionBase.RegionSpeciality>();

        foreach (var item in RegionHolder)
        {
            Region.Add(item);
        }

        foreach (var item in Region)
        {
            if (!TypeCheckList.Contains(item.GetComponent<RegionBase>().RegionType))
            {
                TypeCheckList.Add(item.GetComponent<RegionBase>().RegionType);
            }
        }

        if (TypeCheckList.Count < 4)
        {
            foreach (var item in Region)
            {
                if (TypeCheckList.Contains(item.GetComponent<RegionBase>().RegionType))
                {
                    while (true)
                    {
                        item.GetComponent<RegionBase>().AssignRegionType();

                        if (TypeCheckList.Contains(item.GetComponent<RegionBase>().RegionType)) break;
                    }

                }

                continue;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckRegionQuality()
    {

    }

}
