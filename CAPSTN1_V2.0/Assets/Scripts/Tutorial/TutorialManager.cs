using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {
	public List<TutorialStep> tutorialSteps;
	
	public bool startTutorial;
	public bool isTutorialFinished;
	public int  stepCounter;

	public UnityEvent NextStep;
	
	public MainUI	  mainUI;
	public GameObject startPanel;

	public TutorialStep currentTutorialStepPanel;

	TurnManager turnManager;


	// Use this for initialization
	void Start () 
	{
		if (TurnManager.instance != null)
		{
			turnManager = TurnManager.instance;
		}
		stepCounter = 0;
		transform.SetAsLastSibling();
		turnManager.EndTurnEvent.AddListener(transform.SetAsLastSibling);
		NextStep.AddListener(AdvanceStep);
	}
	
	void Update()
	{
		if (turnManager.currentTurn >= 20)
		{
			Destroy(this.gameObject);
		}
		if (stepCounter >= tutorialSteps.Count)
		{
			isTutorialFinished = true;
		}
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
