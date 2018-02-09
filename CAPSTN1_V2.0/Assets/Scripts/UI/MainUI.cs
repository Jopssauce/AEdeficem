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

    public Text Turn;

    private ResourceManager ResourceMngrRef;
    private TurnManager 	TurnMngrRef;

    // Use this for initialization
    void Start ()
    {
        TurnMngrRef = TurnManager.instance;
        ResourceMngrRef = ResourceManager.instance;
    }

    void Update()
    {
        WaterAmnt.text 	= ResourceMngrRef.water.ToString();
        PowerAmnt.text 	= ResourceMngrRef.power.ToString();
        FoodAmnt.text 	= ResourceMngrRef.food.ToString();
        APAmnt.text 	= ResourceMngrRef.actionPoints.ToString();

        Turn.text = "TURN " + TurnMngrRef.currentTurn;
    }
}