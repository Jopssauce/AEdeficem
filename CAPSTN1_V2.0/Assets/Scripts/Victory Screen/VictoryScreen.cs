using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour {
	public GameObject victoryText;
	public GameObject defeatText;
	string isVictory;
	// Use this for initialization
	void Start () 
	{
		isVictory = PlayerPrefs.GetString("isVictory");
		if (isVictory == "True")
		{
			victoryText.SetActive(true);
		}
		else
		{
			defeatText.SetActive(true);
		}	
	}
	
	
	
}
