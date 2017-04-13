using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Player") {
			Destroy (gameObject);

			CheckAllCollected ();
		}
	}

	void CheckAllCollected() {
		var collectables = GameObject.FindGameObjectsWithTag("Collectable");
		if (collectables.Length == 1) { // 1 as the current one has not been destroyed yet
			GameManager.instance.OnNextLevel ();
		}
	}
}
