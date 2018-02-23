using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public Text WaterAmnt;
    public Text PowerAmnt;
    public Text FoodAmnt;
    public Text APAmnt;

    public Text waterAmntSum;
    public Text powerAmntSum;
    public Text foodAmntSum;
    public Text apAmntSum;

    public Text Turn;

    private ResourceManager resManager;
    private TurnManager 	turnManager;
    private RegionManager   regManager;
    private EventManager    eventManager;

    public List<GameObject> regionUnderlayDisplayList;

    public GameObject regionUnderlayDisplay;
    public GameObject regionOutliner;
    public GameObject regionOutlinerContent;

    public GameObject toggleUnderlayDisplay;
    public bool isUnderlayToggled;
    
    
    // Use this for initialization
    void Start ()
    {
        turnManager = TurnManager.instance;
        resManager  = ResourceManager.instance;
        regManager  = RegionManager.instance;
        eventManager = EventManager.instance;

        foreach (var region in regManager.regionList)
        {
            GameObject ruBar            = Instantiate(regionUnderlayDisplay);
            GameObject ruBarOutliner    = Instantiate(regionOutlinerContent);

            ruBar.GetComponent<RegionUnderlayDisplay>().regionOrigin            = region;
            ruBar.GetComponent<BindToRegion>().regionOrigin 					= region;
            ruBarOutliner.GetComponent<RegionUnderlayDisplay>().regionOrigin    = region;

            regionUnderlayDisplayList.Add(ruBar);
            ruBar.transform.SetParent(this.transform, false);
            ruBarOutliner.transform.SetParent(regionOutliner.transform, false);
        }

       isUnderlayToggled = false;

    }

    void Update()
    {
        WaterAmnt.text 	= resManager.water.ToString();
        PowerAmnt.text 	= resManager.power.ToString();
        FoodAmnt.text 	= resManager.food.ToString();
        APAmnt.text 	= resManager.actionPoints.ToString();

        SumText(waterAmntSum,   resManager.waterSum);
        SumText(powerAmntSum,   resManager.powerSum);
        SumText(foodAmntSum,    resManager.foodSum);
        SumText(apAmntSum,      resManager.actionPointsSum);

        Turn.text = turnManager.currentTurn.ToString();
    }

    void SumText(Text text, int sum)
    {
        if (sum >= 0)
        {
            text.text = "+" + sum.ToString();
        }
        if (sum < 0)
        {
            text.text = "-" + sum.ToString();
        }
    }

    public void toggleRegionUnderlayDisplay()
    {
        foreach (var underlay in regionUnderlayDisplayList)
        {
            if (isUnderlayToggled == false)
            {
                underlay.SetActive(false);
            }
            else
            {
                underlay.SetActive(true);
            }
        }
        isUnderlayToggled = !isUnderlayToggled;
    }
}