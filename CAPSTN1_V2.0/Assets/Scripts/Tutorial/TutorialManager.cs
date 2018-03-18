using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialManager : MonoBehaviour {
	public List<TutorialStep> tutorialSteps;
	public List<TutorialStep> tutorialStepsCopy;
	
	public bool startTutorial;

	public UnityEvent NextStep;
	
	public MainUI	  mainUI;
	public GameObject startPanel;


	// Use this for initialization
	void Start () 
	{
		   transform.SetAsLastSibling();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void StartTutorial()
	{
		startTutorial = true;
		startPanel.SetActive(false);
	}
}
