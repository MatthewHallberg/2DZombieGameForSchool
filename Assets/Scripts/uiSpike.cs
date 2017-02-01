using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiSpike : MonoBehaviour {

	private Color originalColor;
	public GameObject player;
	private Color whiteColor;

	void Start(){

		transform.GetComponentInParent<Renderer> ().material.EnableKeyword("_EMISSION");
		whiteColor = Color.white;
		originalColor = transform.GetComponentInParent<Renderer> ().material.GetColor ("_EmissionColor");
	}

	void OnTriggerEnter2D(Collider2D col){


		if (col.CompareTag("Player")){
			transform.GetComponentInParent<Renderer> ().material.SetColor ("_EmissionColor", whiteColor);
	
			if (!player.GetComponent<characterController> ().hasSpikes && !player.GetComponent<characterController> ().hasSaw) {
				GetComponent<AudioSource> ().Play ();
				player.GetComponent<characterController> ().spikeCount = 4;
				GameObject spikes = Instantiate (Resources.Load ("spikes"), player.transform.position, transform.rotation) as GameObject;
				spikes.transform.localPosition -= new Vector3 (0f, .5f);
				spikes.transform.SetParent (player.transform);
			}
		}

	}

	void OnTriggerExit2D(Collider2D col){
				
		if (col.CompareTag("Player")){
			transform.GetComponentInParent<Renderer> ().material.SetColor ("_EmissionColor", originalColor);
		}
	}

}
