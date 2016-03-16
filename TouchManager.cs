using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TouchManager : MonoBehaviour {

	private bool moveLeft;
	private bool moveRight;
	private bool changePlayer;

	public float forwardSpeed;

	GameObject playerObject;
	public Done_GameController gameController;
	public List <GameObject> changeList;
	public Transform spawnPoint;
	public GameObject countdownGUI;
	bool timer;


    Rigidbody rb;

	void Start(){

		changeList = gameController.GetComponent<Done_GameController> ().playersList;
		countdownGUI.SetActive (false);
	}

	void Update () {
		if (playerObject == null) {
			playerObject = GameObject.FindGameObjectWithTag("Player");
		}
		rb = playerObject.GetComponent<Rigidbody> ();
		if (moveLeft && !moveRight){
			rb.AddForce(-Vector3.right * forwardSpeed);
		}
		if (moveRight && !moveLeft){
			rb.AddForce(Vector3.right * forwardSpeed);
		}
		if (changePlayer && !timer){
			if (GameObject.FindGameObjectWithTag("Player") != null){
				Destroy (GameObject.FindGameObjectWithTag("Player"));
				countdownGUI.SetActive (true);
			}

		}
	}

	public void MoveMeLeft(){
		moveLeft = true;
	}

	public void StopMeLeft(){
		moveLeft = false;
	}

	public void MoveMeRight(){
		moveRight = true;
	}

	public void StopMeRight(){
		moveRight = false;
	}

	public void ChangePlayer(){
		changePlayer = true;
	}

	public void StopChangePlayer(){
		if (GameObject.FindGameObjectWithTag("Player") == null){
			int objectIndex = Random.Range (0, changeList.Count);
			Instantiate (changeList[objectIndex], spawnPoint.position, spawnPoint.rotation);
		}
		changePlayer = false;
		timer = true;
		StartCoroutine (ChangeTime ());
	}

	IEnumerator ChangeTime(){
		
		yield return new WaitForSeconds (30);
		countdownGUI.SetActive (false);
		timer = false;
	}
}
