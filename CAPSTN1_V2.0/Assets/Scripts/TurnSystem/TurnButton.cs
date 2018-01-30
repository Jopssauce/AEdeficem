using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurnButton : MonoBehaviour, IPointerClickHandler {
	public TurnManager turnManager;
	
	void Start()
	{
		if (TurnManager.instance != null)
		{
			turnManager = TurnManager.instance;
		}
	}

	#region IPointerClickHandler implementation
	public void OnPointerClick(PointerEventData eventData)
    {
		if (TurnManager.instance != null)
		{
			turnManager.isTurnEnded = true;
			turnManager.AdvanceTurn();
			Debug.Log("Turn Button Clicked");
		}
        //throw new System.NotImplementedException();
    }
	#endregion
}
