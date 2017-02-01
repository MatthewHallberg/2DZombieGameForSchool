using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterController : MonoBehaviour {

	public float speed;
	public int killCount = 0; 
	public int escaped = 0;
	public GameObject canvas;
	private Text killCountText;
	private Text escapedText; 
	private Text largeText;

	public Rigidbody2D spike;

	public bool hasSpikes;
	public int spikeCount;

	public bool hasSaw;
	public bool activeSaw;

	// Use this for initialization
	void Start () {

		//Get Text component here so we don't have to do it everytime in update function
		killCountText = canvas.transform.GetChild(1).GetComponent<Text> ();
		escapedText = canvas.transform.GetChild (2).GetComponent<Text> ();
		largeText = canvas.transform.GetChild (3).GetComponent<Text> ();

		hasSpikes = false;
		spikeCount = 0;

		hasSaw = false;
		activeSaw = false;
	}

	public void GameOver(){
		
		largeText.transform.GetChild (0).gameObject.SetActive (true);
		largeText.text = "Game Over!";
		//loop through all zombies and destroy
		var zombies = GameObject.FindGameObjectsWithTag("enemy");
		int zombieCount = zombies.Length;
		foreach (GameObject zombie in zombies) {
			Destroy (zombie);
		}
		//find zombie controller object and destroy so no more zombies are spawned
		Destroy(GameObject.Find("zombies"));
		//destroy the player
		Destroy (gameObject);

	}
	
	// Update is called once per frame
	void Update () {
		
		var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		transform.position += move * speed * Time.deltaTime;

		killCountText.text = "Kills: " + killCount;
		escapedText.text = "Escaped: " + escaped;
	
		if (spikeCount == 0) {
			hasSpikes = false;
		} else {
			hasSpikes = true;
		}

		if (Input.GetKeyDown ("space")) {

			if (hasSpikes && !hasSaw) {
				spikeCount--;
				//unchild child 0 of spikes prefab and shoot forward
				try{
				GameObject firstChild = transform.GetChild(0).transform.gameObject.transform.GetChild(0).gameObject;
				firstChild.transform.parent = null;
					firstChild.GetComponent<AudioSource>().Play();
				firstChild.GetComponent<spikeController> ().shouldMove = true;
				Destroy(firstChild.gameObject,3);
				} catch (System.Exception e) {
					spikeCount = 0;
					Destroy (transform.GetChild (0).gameObject);
					print (e);
				}

				if (spikeCount == 0) {
					Destroy (transform.GetChild (0).gameObject);
				}
			}

			if (!hasSpikes && hasSaw) {

				transform.GetChild (0).parent = null;
				hasSaw = false;
			}


		}

	}
}
