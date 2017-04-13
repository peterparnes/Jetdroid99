using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	private bool loadLock;
	public string scene; 
	public float delay = 3f;

	public void OnRestart() {
		Debug.Log("OnRestart");
		if (!loadLock) {
			loadLock = true;
			StartCoroutine (DoRestart ());
		}
	}

	IEnumerator DoRestart() {
		Debug.Log ("Before delay2");
		yield return new WaitForSeconds (delay);
		Debug.Log ("After delay2");
		SceneManager.LoadScene (scene); 

	}
}
