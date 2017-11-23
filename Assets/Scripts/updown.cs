using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updown : MonoBehaviour {

	public float upLimit = -3.0f;
	public float downLimit = -12.0f;
	public float speed = 2.0f;
	private int direction = 1;

	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > upLimit) 
		{
			direction = -1;
		} 
		else if (transform.position.y < downLimit) 
		{
			direction = 1;
		}
		Vector3 movement = Vector3.up * direction * speed * Time.deltaTime;
		transform.Translate (movement);
	}
}
