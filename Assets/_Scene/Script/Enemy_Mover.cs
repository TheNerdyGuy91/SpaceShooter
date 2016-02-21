using UnityEngine;
using System.Collections;

public class Enemy_Mover : MonoBehaviour {

	private Rigidbody rb;
	private float speed;
	void Start () 
	{
		speed = -5;
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;
	}

}
