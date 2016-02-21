using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	void Start () 
	{
		speed = 100;
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;
	}

}
