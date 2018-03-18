using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Step", menuName = "Tutorial/TutorialStep")]
[System.Serializable]
public class TutorialStep : ScriptableObject 
{
	public GameObject tutorialStepPrefab;
	public Vector3 	  uiPos;
	public bool 	  isStepDone;

	[TextArea(3,10)]
	public string tutorialDescription;

}
