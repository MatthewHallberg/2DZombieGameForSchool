using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeController : MonoBehaviour {

	public Rigidbody2D blood;
	private GameObject player;
	public bool shouldMove;
	private GameObject canvas;


	void Start(){

		player = GameObject.FindGameObjectWithTag ("Player");
		canvas = GameObject.Find ("Canvas");
		shouldMove = false;
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.CompareTag("enemy")) {

			Rigidbody2D bloodClone = (Rigidbody2D)Instantiate (blood, col.gameObject.transform.position, transform.rotation);
			bloodClone.GetComponent<AudioSource> ().Play ();
			Destroy(bloodClone.gameObject,.5f);

			player.GetComponent<characterController> ().killCount++;

			//instantiate blood drip clone, set parent to canvas and transform world coordinates to screen coordinates
			GameObject bloodDripClone = Instantiate (Resources.Load ("bloodDrip"), col.transform.position, Quaternion.identity) as GameObject;
			bloodDripClone.transform.SetParent (canvas.transform);

			bloodDripClone.transform.position = canvas.transform.position;

			bloodDripClone.transform.position += col.transform.position * 20f;

			if (UnityEngine.Random.Range (1, 3) == 1) {
				bloodDripClone.transform.eulerAngles = new Vector3 (0, 0, 180f);
			}

			Destroy (bloodDripClone, 2f);

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
