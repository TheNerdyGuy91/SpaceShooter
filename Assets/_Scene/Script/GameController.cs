using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public GUIText scoreText, restartText, gameoverText;
	private int scoreValue;
	public float spawnWait, spawnStart, waveWait;
	private bool gameover, restart;
	void Start ()
	{
		gameover = restart = false;
		gameoverText.text = restartText.text = "";
		StartCoroutine(SpawnWaves ());
		scoreValue = 0;
		UpdateScore ();
	}
	void Update()
	{
		if (restart) 
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds(spawnStart);
		while (true) 
		{
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
			if (gameover)
			{
				restartText.text = "Press R to restart";
				restart = true;
				break;
			}
		}
	}
	public void AddScore(int s)
	{
		scoreValue += s;
		UpdateScore ();
	}
	void UpdateScore()
	{
		scoreText.text = "Score: " + scoreValue;
	}
	public void gameOver()
	{
		gameoverText.text = "Game Over";
		gameover = true;
	}
}