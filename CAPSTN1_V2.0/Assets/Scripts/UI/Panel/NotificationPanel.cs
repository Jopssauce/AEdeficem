using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationPanel : MonoBehaviour {
	public Text text;
	
	public void Start()
	{
		
	}

	public void OnEnable()
	{
		StartCoroutine(disableNotifactionPanel());
	}

	IEnumerator disableNotifactionPanel()
	{
		yield return new WaitForSeconds(2);
		while (this.gameObject.activeSelf == true)
		{
			this.gameObject.SetActive(false);
		}
 		
	}
	
}
