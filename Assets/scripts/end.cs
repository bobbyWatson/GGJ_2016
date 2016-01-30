using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class end : MonoBehaviour {

	public GameObject[] available_ends_bloc;
	private GameObject current_scene;
	private int i = 0;
	private int best_score;
	private int previous_run;
	private string state;

	// Use this for initialization
	void Start () {

		//DEBUG ONLY
		if (!PlayerPrefs.HasKey("best_score")) {
			PlayerPrefs.SetInt ("best_score", 0);
			Debug.Log ("best score set to 0");
		}
		if (!PlayerPrefs.HasKey("nb_run")) {
			PlayerPrefs.SetInt ("nb_run", 0);
			Debug.Log ("run set to 0");
		}
		if (!PlayerPrefs.HasKey("state")) {
			PlayerPrefs.SetString("state", "neutral");
			Debug.Log ("state set to victory");
		}
		//DEBUG ONLY
		PlayerPrefs.SetString("state", "defeat");

		state = PlayerPrefs.GetString ("state");
		//StartCoroutine(SleepSecs(3));
		if (state == "victory") {
			i = 0;
			best_score = PlayerPrefs.GetInt ("best_score");
			Debug.Log("Best score : " + best_score);
			if (PlayerPrefs.GetInt ("run") < best_score) {
				PlayerPrefs.SetInt("best_score", best_score);
				Debug.Log ("new best score");
			}
			PlayerPrefs.SetInt("nb_run", 0);
			Debug.Log ("nb_run reset");
			//need to launch a new game !
		} else if (PlayerPrefs.GetString("state") == "neutral") {
			i = 1;
			//relaunch the same game without incrementing
		} else {
			i = 2;
			previous_run = PlayerPrefs.GetInt ("nb_run");
			PlayerPrefs.SetInt ("nb_run", previous_run++);
			Debug.Log ("Run incremented");
			//relaunch the game and increment
		}
		current_scene = (GameObject) Instantiate(available_ends_bloc[i], new Vector3(0, 1, 20), Quaternion.identity);

	}

	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			if (state == "victory") {
				SceneManager.LoadScene ("Menu");
			} else {
				SceneManager.LoadScene ("Intro");
			}

		}
	}



	IEnumerator SleepSecs (float secs) {
		yield return new WaitForSeconds(secs);
		StartCoroutine(SleepSecs(3));
		//SceneManager.LoadScene ("Main");
	}
}
