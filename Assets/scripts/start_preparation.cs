using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class start_preparation : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//PlayerPrefs.SetString("state", "defeat");
		SceneManager.LoadScene ("Preparation");
	}
}


