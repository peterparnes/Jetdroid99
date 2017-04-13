using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {

	public Debris debris;
	public string restartScene; 
	public float restartDelay = 0.5f;

	public int totalDebris = 10;

	private GameObject gamemaster; 

	// Use this for initialization
	void Start () {
		//gamemaster = GameObject.FindWithTag("GameMaster");
		//Debug.Log (gamemaster);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Deadly") {
			OnExplode ();
		}
	}

	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Deadly") {
			OnExplode ();
		}
	}

	public void OnExplode(){

		var t = transform;

		for (int i = 0; i < totalDebris; i++) {

			t.TransformPoint (0, -100, 0);
			var clone = Instantiate (debris, t.position, Quaternion.identity) as Debris;
			var body2D = clone.GetComponent<Rigidbody2D> ();
			body2D.AddForce (Vector3.right * Random.Range (-1000, 1000));
			body2D.AddForce (Vector3.up * Random.Range (500, 2000));
		}

		// new Restart ().OnRestart (restartScene,restartDelay);

		Destroy (gameObject);

		GameManager.instance.OnRestartCurrentScene ();
	
		// restart.OnRestart (restartScene, restartDelay);

		// StartCoroutine (ScheduleRestart());

	}
		

	/*IEnumerator ScheduleRestart() {
		Debug.Log ("Before delay");
		yield return new WaitForSeconds (restartDelay);
		Debug.Log ("After delay");
		new Restart ().OnRestart (RestartScene);
	}*/
}
