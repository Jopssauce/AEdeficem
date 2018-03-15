using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour {
	public GameObject panel;


    void Start()
    {

    }

    void Update()
    {
    }

    public void Click()
	{
		Destroy(panel);
	}
}
