using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RegionStats : MonoBehaviour
{
    //public Canvas RegionStatsCanvas;
    

    
    
    private RegionManager RegionMngrRef;

    void Start()
    {
        Invoke("DelayAssingManager", 0.3f);
    }

    void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            RegionMngrRef.RegionStatUI.enabled = true;

            RegionMngrRef.RegionStatUI.GetComponent<RegionCanvasScript>().RegionName.text = this.GetComponent<RegionBase>().name;

            RegionMngrRef.RegionStatUI.GetComponent<RegionCanvasScript>().AP.text = this.GetComponent<RegionBase>().RegionResources.Ap.ToString();
            RegionMngrRef.RegionStatUI.GetComponent<RegionCanvasScript>().Water.text = this.GetComponent<RegionBase>().RegionResources.Water.ToString();
            RegionMngrRef.RegionStatUI.GetComponent<RegionCanvasScript>().Power.text = this.GetComponent<RegionBase>().RegionResources.Power.ToString();
            RegionMngrRef.RegionStatUI.GetComponent<RegionCanvasScript>().Food.text = this.GetComponent<RegionBase>().RegionResources.Food.ToString();

            RegionMngrRef.RegionStatUI.GetComponent<RegionCanvasScript>().RegionQuality.text = this.GetComponent<RegionBase>().RegionQuality.ToString();
        }
    }

    void DelayAssingManager()
    {
        RegionMngrRef = RegionManager.instance;
    }
}