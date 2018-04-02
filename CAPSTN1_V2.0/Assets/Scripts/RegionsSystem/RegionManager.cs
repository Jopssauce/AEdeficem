using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class RegionManager : MonoBehaviour
{
    public List<RegionBase> regionList;
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

        RegionHolder = GameObject.FindGameObjectsWithTag("Region");

        TypeCheckList       = new List<ResourceManager.ResourceType>();
        Duplicates          = new List<GameObject>();
        MissingRegionType   = new List<ResourceManager.ResourceType>();

        MakeRegionStatsCanvas();

        for (int i = 0; i < 4; i++)
        {
            if ((ResourceManager.ResourceType)i != ResourceManager.ResourceType.ActionPoints)
            {
                MissingRegionType.Add((ResourceManager.ResourceType)i);
            }
            
        }
        FixRegionTypes();
	}
	void OnDestroy()
	{
		instance = null;
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
            regionList.Add(item.GetComponent<RegionBase>());
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
       
        }

        bool isVictory;
        if (turnManager.currentTurn >= 100)
        {
            if (regionList.All(region => region.GetComponent<RegionBase>().regionQuality >= 70))
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

		if (turnManager.currentTurn % 10 == 0) 
		{
			foreach (RegionBase r in regionList) 
			{
				
			}
		}
    }
}
