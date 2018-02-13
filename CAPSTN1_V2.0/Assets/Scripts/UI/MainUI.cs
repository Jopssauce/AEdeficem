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

    public GameObject regionUnderlayDisplay;
    
    // Use this for initialization
    void Start ()
    {
        turnManager = TurnManager.instance;
        resManager  = ResourceManager.instance;
        regManager  = RegionManager.instance;

        foreach (var region in regManager.regionList)
        {
            GameObject ruBar = Instantiate(regionUnderlayDisplay);
            ruBar.GetComponent<RegionUnderlayDisplay>().regionOrigin = region;
            ruBar.transform.SetParent(this.transform, false);
        }

       

    }

    void Update()
    {
        WaterAmnt.text 	= resManager.water.ToString();
        PowerAmnt.text 	= resManager.power.ToString();
        FoodAmnt.text 	= resManager.food.ToString();
        APAmnt.text 	= resManager.actionPoints.ToString();

        //waterAmntSum.text   = resManager.waterSum.ToString();
        //powerAmntSum.text   = resManager.powerSum.ToString();
        //foodAmntSum.text    = resManager.foodSum.ToString();
        //apAmntSum.text      = resManager.actionPointsSum.ToString();

        SumText(waterAmntSum,   resManager.waterSum);
        SumText(powerAmntSum,   resManager.powerSum);
        SumText(foodAmntSum,    resManager.foodSum);
        SumText(apAmntSum,      resManager.actionPointsSum);

        Turn.text = "TURN " + turnManager.currentTurn;
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
}