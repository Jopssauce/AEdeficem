﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegionCanvasScript : MonoBehaviour
{
    public Text RegionName;
    public Text ResourceAmount;

    public Text RegionQuality;
    public Button Close;

    void Start()
    {
        Close.onClick.AddListener(Destroy);
    }

    void Destroy()
    {
        this.gameObject.SetActive(false);
    }
}