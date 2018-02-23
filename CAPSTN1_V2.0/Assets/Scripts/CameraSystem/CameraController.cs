using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public float speed;


	void Update () 
	{
		
		//Debug.Log(Camera.main.WorldToViewportPoint(Input.mousePosition));
		if (Input.GetAxisRaw("Horizontal") != 0)
		{
			transform.position += Vector3.right * Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
		}
		if (Input.GetAxisRaw("Vertical") != 0)
		{
			transform.position += Vector3.forward * Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
		}

		if (Input.mousePosition.x > Screen.width - 100)
		{
			transform.position += Vector3.right * 1 * speed * Time.deltaTime;
		}
		if (Input.mousePosition.x < 100)
		{
			transform.position += Vector3.right * -1 * speed * Time.deltaTime;
		}
		if (Input.mousePosition.y > Screen.height - 100)
		{
			transform.position += Vector3.forward * 1 * speed * Time.deltaTime;
		}
		if (Input.mousePosition.y < 50)
		{
			transform.position += Vector3.forward * -1 * speed * Time.deltaTime;
		}
		Vector3 clampedPos = transform.position;
		clampedPos.z = Mathf.Clamp(transform.position.z, -13f, 3f);
		clampedPos.x = Mathf.Clamp(transform.position.x, -5f, 5f);
		transform.position = clampedPos;
	}
}
