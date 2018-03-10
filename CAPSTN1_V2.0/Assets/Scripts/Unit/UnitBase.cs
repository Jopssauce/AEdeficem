﻿using System.Collections;
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
		destPos.x = eventOrigin.eventWorldPos.x;
		destPos.y = this.transform.position.y;
		destPos.z = eventOrigin.eventWorldPos.z;
		eventOrigin.unit = this;
	}

	void Update()
	{
		distance = destPos - this.transform.position;
		if (isSend == true && isArrived == false)
		{
			MoveTowards();
		}
		/*if (isSend == false && isArrived == true)
		{
			MoveTowards();
		}
		if (isReturned == true)
		{
			Destroy(this.gameObject);
		}*/
	}

	public void MoveTowards()
	{
		 velocity = distance.normalized * 2;
		 if (distance.magnitude <= 0.3f && isArrived == false)
		 {
			 isArrived = true;
		 }
		  if (distance.magnitude <= 0.3f && isReturned == false)
		 {
			 isReturned = true;
		 }
		 transform.position += velocity * Time.deltaTime;
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
