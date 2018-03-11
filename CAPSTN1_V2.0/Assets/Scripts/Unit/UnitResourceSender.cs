using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitResourceSender : UnitBase {

	[System.Serializable]
	 public class UnitResources
    {
        public int Water;
        public int Power;
        public int Food;
    }

	public UnitResources unitResources;
	public CityBase 	 target;

	public override void Start()
	{
		base.Start();
		destPos.x = target.transform.position.x;
		destPos.y = this.transform.position.y;
		destPos.z = target.transform.position.z;
		turnManager.EndTurnEvent.AddListener(SendResource);
	}

	public override void Update()
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
		if (isArrived == true)
		{
			Destroy(this.gameObject);
		}
		
	}

	public void StoreResource(CityBase.ProductionType type, int amount)
	{
		switch (type) 
		{
		case CityBase.ProductionType.Water:
			cityOrigin.cityResources.Water -= amount;
			unitResources.Water += amount;
			break;
		case CityBase.ProductionType.Food:
			cityOrigin.cityResources.Food -= amount;
			unitResources.Food += amount;
			break;
		case CityBase.ProductionType.Power:
			cityOrigin.cityResources.Power -= amount;
			unitResources.Power += amount;
			break;
		default:
			Debug.Log ("Cant add Resource");
			break;
		}
		cityOrigin.AdjustedCityResource.Invoke ();
	}

	public void SendResource()
	{
		if (isSend == true)
		{
			target.AddCityResource(CityBase.ProductionType.Water, unitResources.Water);
			target.AddCityResource(CityBase.ProductionType.Food, unitResources.Food);
			target.AddCityResource(CityBase.ProductionType.Power, unitResources.Power);
		}
	}
	public override void Initiate()
	{
		if (isArrived == false)
		{
			isSend = true;
		}
	}
}
