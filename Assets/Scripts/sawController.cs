using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawController : MonoBehaviour {

	public Rigidbody2D blood;
	private GameObject player;
	private int zombiesKilled;

	void Start(){

		player = GameObject.FindGameObjectWithTag ("Player");
		zombiesKilled = 0;
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.CompareTag("enemy")) {

			GameObject.Find ("saw").GetComponent<AudioSource> ().Play ();
			player.GetComponent<characterController> ().killCount++;

			Rigidbody2D bloodClone = (Rigidbody2D)Instantiate (blood, col.gameObject.transform.position, transform.rotation);
			bloodClone.GetComponent<AudioSource> ().Play ();
			Destroy(bloodClone.gameObject,.5f);

			Destroy (col.gameObject);
			zombiesKilled++;

			if (zombiesKilled == 5) {
				player.GetComponent<characterController> ().activeSaw = false;
				player.GetComponent<characterController> ().hasSaw = false;
				Destroy (gameObject);
			}

		}


	}

}
