using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchTabs : MonoBehaviour {

    public Transform Tab;
    // Use this for initialization

    public void ShowTab()
    {
        Debug.Log("ButtonClicked");
        Tab.SetAsLastSibling();
    }
}
