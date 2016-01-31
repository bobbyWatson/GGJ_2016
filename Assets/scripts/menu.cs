using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menu : MonoBehaviour {

	//private int best_score;
	//private int nb_run;
	// Use this for initialization
	private Text Best_score_display;

	void Start () {
		Debug.Log ("menu screen");
		//Best_score_display = GameObject.FindGUIWithTag ("best_score");
		Best_score_display = GameObject.Find("best_score").GetComponent<Text>();
		//best_score = PlayerPrefs.GetInt ("best_score");
		//nb_run = PlayerPrefs.GetInt ("run");
		if (!PlayerPrefs.HasKey ("best_score") || PlayerPrefs.GetInt ("best_score") == 0) {
			PlayerPrefs.SetInt ("best_score", 0);
			Debug.Log ("best score set to 0");
			Best_score_display.text = "No best score yet";
		} else {
			Best_score_display.text = "Best score : " + PlayerPrefs.GetInt ("best_score");
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
