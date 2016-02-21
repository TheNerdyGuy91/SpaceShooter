using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

		public float tumble;
		private Rigidbody rb;
	// Use this for initialization
	void Start () {
		tumble = 5;
		rb = GetComponent<Rigidbody>();
		rb.angularVelocity = Random.insideUnitSphere * tumble;
	}

}
