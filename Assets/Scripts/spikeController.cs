using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeController : MonoBehaviour {

	public Rigidbody2D blood;
	private GameObject player;
	public bool shouldMove;


	void Start(){

		player = GameObject.FindGameObjectWithTag ("Player");
		shouldMove = false;
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.CompareTag("enemy")) {

			player.GetComponent<characterController> ().killCount++;

			Rigidbody2D bloodClone = (Rigidbody2D)Instantiate (blood, col.gameObject.transform.position, transform.rotation);
			bloodClone.GetComponent<AudioSource> ().Play ();
			Destroy(bloodClone.gameObject,.5f);

			Destroy (col.gameObject);
			Destroy (gameObject);
		}


	}

	void Update(){

		if (shouldMove) {

			transform.position = new Vector3 (transform.position.x + .1f, transform.position.y);
		}

	}
}
