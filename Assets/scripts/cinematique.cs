using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class cinematique : MonoBehaviour {

	public GameObject[] cinematique_bloc;
	private GameObject current_scene;
	private int i = 0;
	private int nb_screen = 1;

	// Use this for initialization
	void Start () {
		StartCoroutine(SleepSecs(3));
		current_scene = (GameObject) Instantiate(cinematique_bloc[i], new Vector3(0, 1, 20), Quaternion.identity);
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
