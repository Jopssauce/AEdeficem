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
	EventManager eventManager;


	// Use this for initialization
	void Start () 
	{
		if (TurnManager.instance != null)
		{
			turnManager = TurnManager.instance;
		}
		if (EventManager.instance != null)
		{
			eventManager = EventManager.instance;
		}
		eventManager.maxEvents = 1;
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
			eventManager.maxEvents = 8;
		}
		//transform.SetAsLastSibling();
	}
	
	public void StartTutorial()
	{
		FindObjectOfType<AudioManager> ().Play ("Generic");
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
			currentTutorialStepPanel = (tutorialSteps[stepCounter-1]);
			//Important for fixing resolution
			currentTutorialStepPanel.gameObject.SetActive(true);
			//currentTutorialStepPanel.gameObject.transform.SetParent(transform, false);
			//Vector2 pos = currentTutorialStepPanel.GetComponent<RectTransform>().localPosition;
			//currentTutorialStepPanel.GetComponent<RectTransform>().localPosition = new Vector2( pos.x , pos.y * ScreenScale().y);
			currentTutorialStepPanel.tutorialUI = this;
		}
		
	}

	void OnDestroy()
	{
		isTutorialFinished = true;
		eventManager.maxEvents = 8;
	}
	
	Vector2 ScreenScale()
	{
		CanvasScaler cs = transform.parent.GetComponent<CanvasScaler>();
		return new Vector2(cs.referenceResolution.x / Screen.width, cs.referenceResolution.y / Screen.height);
	}
}
