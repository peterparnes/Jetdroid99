using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienB : MonoBehaviour {

	private Animator animator;
	private bool readyToAttack;

	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> ();

	}
	
	void OnTriggerStay2D(Collider2D target) {
		if (target.gameObject.tag == "Player") {
			if (readyToAttack) {
				var explode = target.GetComponent<Explode> ();
				explode.OnExplode ();
			} else {
				animator.SetInteger ("AnimState", 1);
			}
		} else if (target.gameObject.tag == "Deadly") {
			animator.SetInteger ("AnimState", 1);
			StartCoroutine (ToggleAnimState ());
		}
	}

	void InTriggerExit2D(Collider2D target) {
		readyToAttack = false;
		animator.SetInteger ("AnimState", 0);
	}

	void Attack() {
		readyToAttack = true; 
	}

	IEnumerator ToggleAnimState() {
		yield return new WaitForSeconds (1);
		animator.SetInteger ("AnimState", 0);
	}
}
