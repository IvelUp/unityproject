using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

//	public GameObject target;
//	public float moveSpeed = 500;
//	private Rigidbody rb;
	// Use this for initialization
//	void Start () {
//		if (target == null) {
//			target = GameObject.FindGameObjectWithTag("Player");
//		}
//
//		rb = GetComponent<Rigidbody>();
//
//	}

	void Update () {

		this.transform.position = GameObject.FindGameObjectWithTag ("Player").transform.position;
		this.transform.rotation = GameObject.FindGameObjectWithTag ("Player").transform.rotation;
	}
}
