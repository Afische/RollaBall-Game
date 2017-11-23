﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	public Transform RespawnPoint;
	public GameObject Player;

	private Rigidbody rb;
	private int count;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal"); //controlled by keyboard
		float moveVertical = Input.GetAxis ("Vertical"); //controlled by keyboard
	
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
		if (other.gameObject.CompareTag("RespawnGround"))
		{
			Player.transform.position = RespawnPoint.transform.position;
		}
		if (other.gameObject.CompareTag("Reset"))
		{
			Player.transform.position = RespawnPoint.transform.position;
		}
	}

	void SetCountText ()
	{
		countText.text = "Score: " + count.ToString ();
		if (count >= 28) 
		{
			winText.text = "YOU WIN!";
		}
	}
}