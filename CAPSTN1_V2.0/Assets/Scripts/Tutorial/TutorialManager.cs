using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {
	public List<TutorialStep> tutorialSteps;
	
	public bool startTutorial;
	public int  stepCounter;

	public UnityEvent NextStep;
	
	public MainUI	  mainUI;
	public GameObject startPanel;

	public TutorialStep currentTutorialStepPanel;


	// Use this for initialization
	void Start () 
	{
		stepCounter = 0;
		transform.SetAsLastSibling();

		NextStep.AddListener(AdvanceStep);
	}
	
	
	public void StartTutorial()
	{
		startTutorial = true;
		Destroy(startPanel.gameObject);
		NextStep.Invoke();
	}

	public void AdvanceStep()
	{
		stepCounter++;
		if (currentTutorialStepPanel != null)
		{
			Destroy(currentTutorialStepPanel.gameObject);
		}
		
		if (stepCounter <= tutorialSteps.Count)
		{
			currentTutorialStepPanel = Instantiate(tutorialSteps[stepCounter-1]);
			currentTutorialStepPanel.tutorialUI = this;
		}
		
	}
}
