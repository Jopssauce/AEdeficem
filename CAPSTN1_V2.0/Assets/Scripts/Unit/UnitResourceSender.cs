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
		unitResources.Water = 0;
		unitResources.Power = 0;
		unitResources.Food 	= 0;
	}

	public override void Update()
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
		if (eventOrigin == null)
		{
			Destroy(this.gameObject);
		}
	}

	public void StoreResource(CityBase.ProductionType type, int amount)
	{
		switch (type) 
		{
		case CityBase.ProductionType.Food:
			cityOrigin.cityResources.Food -= amount;
			unitResources.Food += amount;
			break;
		case CityBase.ProductionType.Power:
			cityOrigin.cityResources.Power -= amount;
			unitResources.Power += amount;
			break;
		case CityBase.ProductionType.Water:
			cityOrigin.cityResources.Water -= amount;
			unitResources.Water += amount;
			break;
		default:
			Debug.Log ("Cant add Resource");
			break;
		}
		cityOrigin.AdjustedCityResource.Invoke ();
	}

	public void SendResource()
	{
		if (isArrived == true)
		{
			
		}
	}
}
