using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour {

	public static Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	public static void DoJump(float jumpForce)
	{
		rb.AddForce (Vector2.up * jumpForce);
	}

}
