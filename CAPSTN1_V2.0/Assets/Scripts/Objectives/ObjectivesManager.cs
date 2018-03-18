using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivesManager : MonoBehaviour 
{
	public List<Objectives> objectivesList;
	public List<Objectives> objectivesListCopy;
	public GameObject  	  	objectivePrefab;

	public void Start()
	{
		if (objectivesList != null)
		{
			foreach (var item in objectivesList)
			{
				objectivesListCopy.Add(item);
			}
		}
	}

}
