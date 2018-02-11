using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RegionStats : MonoBehaviour
{

    private RegionManager RegionMngrRef;

    void Start()
    {
        Invoke("DelayAssingManager", 0.3f);
    }

    void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            RegionMngrRef.RegionStatUI.SetActive(true);

            RegionMngrRef.RegionStatUI.GetComponent<RegionCanvasScript>().RegionName.text = this.GetComponent<RegionBase>().name;

            RegionMngrRef.RegionStatUI.GetComponent<RegionCanvasScript>().ResourceAmount.text = this.GetComponent<RegionBase>().regionResourceAmount.ToString();

			RegionMngrRef.RegionStatUI.GetComponent<RegionCanvasScript>().RegionQuality.text = this.GetComponent<RegionBase>().regionQuality.ToString();
        }
    }

    void DelayAssingManager()
    {
        RegionMngrRef = RegionManager.instance;
    }
}