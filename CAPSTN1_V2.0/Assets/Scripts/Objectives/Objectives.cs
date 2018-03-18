using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Objective", menuName = "Objective/Objective")]
[System.Serializable]
public class Objectives : ScriptableObject 
{
    public GameObject objectivesPrefab;
	public Vector3 	  uiPos;
	public bool 	  isObjectiveDone;

	[TextArea(3,10)]
	public string objectiveDescription;

    public void ObjectiveDone()
    {
        isObjectiveDone = false;
    }
}
