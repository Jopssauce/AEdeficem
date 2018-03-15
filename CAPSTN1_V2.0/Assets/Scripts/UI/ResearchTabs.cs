using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchTabs : MonoBehaviour {

    public void ShowTab()
    {
        Debug.Log("ButtonClicked");
		this.transform.parent.transform.SetAsLastSibling ();
    }
}
