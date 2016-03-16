using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownTimer : MonoBehaviour {

	public float countdownTimer = 30;
	private Text countdownText;

	void Start () {
		countdownText = GetComponent<Text>();
	}

	void Update () {
		if (countdownTimer <= 30 && countdownTimer >= 0) {
			countdownTimer -= Time.deltaTime;
			countdownText.text = countdownTimer.ToString ("f0");
		} else {
			countdownTimer = 30;
		}
		print (countdownTimer);
	}
}
