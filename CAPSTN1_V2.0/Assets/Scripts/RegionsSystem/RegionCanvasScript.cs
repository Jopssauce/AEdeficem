using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegionCanvasScript : MonoBehaviour
{
    public Text RegionName;
    public Text AP;
    public Text Food;
    public Text Water;
    public Text Power;

    public Text RegionQuality;
    public Button Close;

    void Start()
    {
        Close.onClick.AddListener(Destroy);
    }

    void Destroy()
    {
        this.GetComponent<Canvas>().enabled = false;
    }
}