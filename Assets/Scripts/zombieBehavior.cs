using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieBehavior : MonoBehaviour {

	private float speed;
	private float positionY;
	private float positionX;
	private GameObject player;

	// Use this for initialization
	void Start () {

		speed = 0.02f;
		positionY = UnityEngine.Random.Range (-4f, -.16f);
		positionX = 12f;

		player = GameObject.FindGameObjectWithTag ("Player");

		transform.position = new Vector3 (positionX, positionY);

	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.name == "fieldEdge") {

			player.GetComponent<characterController> ().escaped++;
			Destroy (gameObject);
		}

		if (col.CompareTag("Player")) {

			player.GetComponent<characterController>().GameOver();
		}


	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 (transform.position.x - speed, transform.position.y );

	}
}
