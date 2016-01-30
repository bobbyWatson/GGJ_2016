using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour {

	//private int best_score;
	//private int nb_run;
	// Use this for initialization
	void Start () {
		Debug.Log ("menu screen");
		//best_score = PlayerPrefs.GetInt ("best_score");
		//nb_run = PlayerPrefs.GetInt ("run");
		if (!PlayerPrefs.HasKey("best_score")) {
			PlayerPrefs.SetInt ("best_score", 0);
			Debug.Log ("best score set to 0");
		}
		if (!PlayerPrefs.HasKey("run")) {
			PlayerPrefs.SetInt ("nb_run", 0);
			Debug.Log ("run set to 0");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
