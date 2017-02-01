using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiSaw : MonoBehaviour {

	private Color originalColor;
	public GameObject player;
	public GameObject saw;
	private Color whiteColor;

	void Start(){

		transform.GetComponentInParent<Renderer> ().material.EnableKeyword("_EMISSION");
		whiteColor = Color.white;
		originalColor = transform.GetComponentInParent<Renderer> ().material.GetColor ("_EmissionColor");

	}

	void OnTriggerEnter2D(Collider2D col){


		if (col.CompareTag("Player")){

			transform.GetComponentInParent<Renderer> ().material.SetColor ("_EmissionColor", whiteColor);

			if (!player.GetComponent<characterController> ().hasSaw && !player.GetComponent<characterController> ().hasSpikes && !player.GetComponent<characterController> ().activeSaw) {
				player.GetComponent<characterController> ().hasSaw = true;
				player.GetComponent<characterController> ().activeSaw = true;
				GameObject saw = Instantiate (Resources.Load ("sawBlade"), player.transform.position, transform.rotation) as GameObject;
				saw.transform.localPosition -= new Vector3 (0f, 1.1f);
				saw.transform.SetParent (player.transform);
			}
		}

	}

	void OnTriggerExit2D(Collider2D col){

		if (col.CompareTag("Player")){
			transform.GetComponentInParent<Renderer> ().material.SetColor ("_EmissionColor", originalColor);
		}
	}

}
