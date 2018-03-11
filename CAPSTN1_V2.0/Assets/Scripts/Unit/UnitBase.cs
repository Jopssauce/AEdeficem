using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour 
{
	public TurnManager 		turnManager;
	public CityBase 		cityOrigin;
	public EventPopUpBase	 eventOrigin;

	public LineRenderer lineRenderer;

	public Vector3 destPos;
	public Vector3 velocity;
	public Vector3 distance;
	public bool isArrived;
	public bool isReturn;
	public bool isReturned;
	public bool isSend;

	public virtual void Start()
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
		if (eventOrigin != null)
		{
			destPos.x = eventOrigin.eventWorldPos.x;
			destPos.y = this.transform.position.y;
			destPos.z = eventOrigin.eventWorldPos.z;
			eventOrigin.unit = this;
		}
		lineRenderer.GetComponent<LineRenderer>();
		lineRenderer.startWidth = .07f;
		lineRenderer.endWidth = .07f;
		
		
	}

	public virtual void Update()
	{
		lineRenderer.SetPosition(0, this.transform.position);
		lineRenderer.SetPosition(1, destPos);
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
		if (eventOrigin == null)
		{
			Destroy(this.gameObject);
		}
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

	public virtual void Initiate()
	{
		if (eventOrigin != null && isArrived == false)
		{
			isSend = true;
		}
	}
	
}
