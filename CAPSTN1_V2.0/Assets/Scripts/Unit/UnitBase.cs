using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour 
{
	TurnManager 			turnManager;
	public CityBase 		cityOrigin;
	public EventPopUpBase	 eventOrigin;

	public Vector3 destPos;
	public Vector3 velocity;
	Vector3 distance;
	public bool isArrived;
	public bool isReturn;
	public bool isReturned;
	public bool isSend;

	void Start()
	{
		isArrived = false;
		isSend = false;
		isReturn = false;
		if (TurnManager.instance != null)
		{
			turnManager = TurnManager.instance;
		}
		turnManager.EndTurnEvent.AddListener(Initiate);
		turnManager.EndTurnEvent.AddListener(ReturnToCity);
		destPos = eventOrigin.transform.position;
	}

	void Update()
	{
		distance = destPos - this.transform.position;
		if (isSend == true && isArrived == false)
		{
			MoveTowards();
		}
		if (isSend == false && isArrived == true)
		{
			MoveTowards();
		}
		if (isReturned == true)
		{
			Destroy(this.gameObject);
		}
	}

	public void MoveTowards()
	{
		 velocity = distance.normalized * 5;
		 if (distance.magnitude <= 1 && isArrived == false)
		 {
			 isArrived = true;
		 }
		  if (distance.magnitude <= 1 && isReturned == false)
		 {
			 isReturned = true;
		 }
		 transform.position += velocity;
	}
	
	public void ReturnToCity()
	{
		if (isArrived == true && isSend == false)
		{
			isReturn = true;
		}
	}

	public void Initiate()
	{
		if (eventOrigin != null && isArrived == false)
		{
			isSend = true;
		}
	}
	
}
