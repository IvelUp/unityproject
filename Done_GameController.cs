using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Done_GameController : MonoBehaviour
{
	//List of players
	public List <GameObject> playersList = new List<GameObject>();
	//Players GameObejects
	public GameObject[] players;


	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	public Text scoreText;
//	public Text restartText;
	public Text gameOverText;
	public GameObject restartButton;
	public GameObject changeButton;
	public GameObject countdownGUI;
//	public GameObject fireButton;
	
	private bool gameOver;
	private bool restart;
	private int score;
	
	void Start ()
	{
		gameOver = false;
		restart = false;
//		restartText.text = "";
		gameOverText.text = "";
		restartButton.SetActive (false);
		countdownGUI.SetActive (false);
		changeButton.SetActive (true);
//		fireButton.SetActive (true);
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
		for (int i = 0; i < players.Length; i++) {
			playersList.Add(players[i]);
		}

	}
	
//	void Update ()
//	{
//		if (restart)
//		{
//			if (Input.GetKeyDown (KeyCode.R))
//			{
//				Application.LoadLevel (Application.loadedLevel);
//			}
//		}
//	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			
			if (gameOver)
			{
				//restartButton.SetActive (true);
//				fireButton.SetActive (false);
//				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}
	
//	public void AddScore (int newScoreValue)
//	{
//		score += newScoreValue;
//		UpdateScore ();
//	}

	public void AddScore ()
	{
		score += 1;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}
	
	public void GameOver ()
	{
		countdownGUI.SetActive (false);
		changeButton.SetActive (false);
		restartButton.SetActive (true);
		gameOverText.text = "Game Over!";
		gameOver = true;
	}

	public void RestartGame (){
		Application.LoadLevel (Application.loadedLevel);
	}
}