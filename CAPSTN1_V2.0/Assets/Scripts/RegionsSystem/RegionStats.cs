using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionStats : MonoBehaviour
{
    private RegionBase RegionRef;

    void Start()
    {
        RegionRef = this.GetComponent<RegionBase>();
    }

    void OnMouseDown()
    {
        Debug.Log(RegionRef.name);
    }
}
