using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegionStats : MonoBehaviour
{
    public Canvas RegionStatsCanvas;

    private RegionBase RegionRef;

    void Start()
    {
        RegionRef = this.GetComponent<RegionBase>();
    }

    void OnMouseDown()
    {
        Canvas RegionStatUI = Instantiate(RegionStatsCanvas) as Canvas;
    }
}