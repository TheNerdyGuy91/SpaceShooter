using UnityEngine;
using System.Collections;
[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour {

	public float speed;
	public Boundary boundary;
	private Rigidbody rb;
	private float tilt;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire; 
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		speed = 10;
		tilt = 4;
	}
	void Update()
	{ 
		if (Input.GetButton("Jump") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			
			Instantiate(shot, transform.position, transform.rotation);
			GetComponent<AudioSource>().Play();
		}
	}
	// Update is called once per frame
	void FixedUpdate () 
	{
		// getting input from user
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (h, 0.0f, v);
		rb.velocity = movement * speed; // to get a proper speed
		// position
		rb.position = new Vector3 (
		Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
		0.0f, 
		Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax));
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}
 