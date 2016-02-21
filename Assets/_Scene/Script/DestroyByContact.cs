using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gc; 
	void Start()
	{
		GameObject gco = GameObject.FindWithTag ("GameController");
			if (gco != null)
		{
			gc = gco.GetComponent<GameController>();
		}
		if (gc == null)
		{
			Debug.Log("Cannot be found");
		}
	}
	void OnTriggerEnter (Collider obj)
	{
		if (obj.tag == "Boundary") 
		{
			return;
		}
		Instantiate (explosion, transform.position, transform.rotation);
		if (obj.tag == "Player") 
		{
			Instantiate (playerExplosion, obj.transform.position, obj.transform.rotation);
			gc.gameOver();
		}
		gc.AddScore(10);
		Destroy (obj.gameObject);
		Destroy (gameObject);

	}
}
