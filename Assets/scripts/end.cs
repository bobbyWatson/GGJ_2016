using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class end : MonoBehaviour {

	public GameObject[] available_ends_bloc;
	private GameObject current_end;
	private int i = 0;

	// Use this for initialization
	void Start () {
		//StartCoroutine(SleepSecs(3));
		if (PlayerPrefs.state == "victory") {
			i = 0;
			//need to launch a new game !
		} else if (PlayerPrefs.state == "victory") {
			i = 1;
			//relaunch the same game without incrementing
		} else {
			i = 2;
			//relaunch the game and increment
		}
		current_scene = (GameObject) Instantiate(available_ends_bloc[i], new Vector3(0, 1, 20), Quaternion.identity);

	}

	// Update is called once per frame
	void Update () {

	}


	IEnumerator SleepSecs (float secs) {
		yield return new WaitForSeconds(secs);
		StartCoroutine(SleepSecs(3));
		if (i == nb_screen) {
			SceneManager.LoadScene ("Main");
		} else {
			Destroy(current_scene);
			i++;
			current_scene = (GameObject) Instantiate(cinematique_bloc[i], new Vector3(0, 1, 20), Quaternion.identity);
		}
	}
}
