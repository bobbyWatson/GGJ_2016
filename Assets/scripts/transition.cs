using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class transition : MonoBehaviour {

	public GameObject[] cinematique_bloc;
	private GameObject current_scene;
	private int i = 0;
	private int nb_screen = 1;
	private Text Nb_run_display;

	private float startTime;

	// Use this for initialization
	void Start () {

		startTime = Time.time;
		//StartCoroutine(SleepSecs(3));

		/*
		current_scene = (GameObject) Instantiate(cinematique_bloc[i], new Vector3(0, 1, 20), Quaternion.identity);
		Nb_run_display = GameObject.Find("nb_run").GetComponent<Text>();
		Debug.Log (PlayerPrefs.GetInt ("nb_run"));
		Debug.Log (PlayerPrefs.GetInt ("nb_run") == 0);
		if (!PlayerPrefs.HasKey ("nb_run") || PlayerPrefs.GetInt ("nb_run") == 0) {
			PlayerPrefs.SetInt ("nb_run", 1);
			Debug.Log ("current run set to 1");
			Nb_run_display.text = "Run no " + 1;
		} else {
			PlayerPrefs.SetInt ("nb_run", PlayerPrefs.GetInt ("nb_run") + 1);
			Nb_run_display.text = "Run no " + PlayerPrefs.GetInt ("nb_run");
		}
		*/
	}

	// Update is called once per frame
	void Update () {
		if (Time.time-startTime > 2f && Input.anyKeyDown) {
			SceneManager.LoadScene ("Manu");
		}
	}


	IEnumerator SleepSecs (float secs) {
		yield return new WaitForSeconds(secs);
		StartCoroutine(SleepSecs(3));
		if (i == nb_screen) {
			SceneManager.LoadScene ("Manu");
		} else {
			Destroy(current_scene);
			i++;
			current_scene = (GameObject) Instantiate(cinematique_bloc[i], new Vector3(0, 1, 20), Quaternion.identity);
		}
	}
}
