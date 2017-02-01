using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class resartButton : MonoBehaviour {



	public void restartButtonDown(){

		SceneManager.LoadScene (0);
	}

	void Start(){

		StartCoroutine ("changeButtonColor");
	}

	IEnumerator changeButtonColor(){

		while (true) {
			GetComponent<Image> ().color = Color.gray;
			yield return new WaitForSeconds (.5f);
			GetComponent<Image> ().color = Color.black;
			yield return new WaitForSeconds (.5f);
		}
	}

}
