using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieCreator : MonoBehaviour {


	public Rigidbody2D zombie;
	public int frameDelta;
	private int counter;

	// Use this for initialization
	void Start () {

		counter = 1;
		frameDelta = 50;
	}
	
	// Update is called once per frame
	void Update () {

		counter++;

		if (counter % frameDelta == 0) {
			Rigidbody2D zombieClone = (Rigidbody2D)Instantiate (zombie, transform.position, transform.rotation);
		}

	}
}
