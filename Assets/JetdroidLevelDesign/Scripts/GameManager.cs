using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
	// private BoardManager boardScript;                       //Store a reference to our BoardManager which will set up the level.
	private int level = 3;                                  //Current level number, expressed in game as "Day 1".


	// XXX
	// private bool loadLock;
	public string splashscene; 
	public float delay = 2.2f;

	private string currentscene; 

	//Awake is always called before any Start functions
	void Awake()
	{
		//Check if instance already exists
		if (instance == null)

			//if not, set instance to this
			instance = this;

		//If instance already exists and it's not this:
		else if (instance != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy (gameObject);    

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad (gameObject);

		//Get a component reference to the attached BoardManager script
		// boardScript = GetComponent<BoardManager> ();

		currentscene = splashscene; 

		//Call the InitGame function to initialize the first level 
		InitGame ();
	}

	//Initializes the game for each level.
	void InitGame()
	{
		//Call the SetupScene function of the BoardManager script, pass it current level number.
		// boardScript.SetupScene(level);


	}

	public void OnRestartCurrentScene() {
		currentscene = SceneManager.GetActiveScene ().name;
		Debug.Log("Active scene is '" + currentscene + "'.");
		OnRestart ();
	}

	public void OnRestart() {
		Debug.Log("OnRestart");
		//if (!loadLock) {
		//	loadLock = true;
			StartCoroutine (DoRestart ());
		//}
	}

	IEnumerator DoRestart() {
		Debug.Log ("Before delay2");
		yield return new WaitForSeconds (delay);
		Debug.Log ("After delay2");
		SceneManager.LoadScene (currentscene); 
	}
		
}
