using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public int score;
	public ScoreUnit[] units;

	public void AddPoints(int points){
		for (int i = 0; i < points; i++) {
			if (score + 1 <= 0) {
				units [units.Length + score].GoToNormal ();
				score++;
			} else if (score < units.Length) {
				units [score].GoToHappy ();
				score++;
			}
		}
	}

	public void RemovePoints(int points){
		for (int i = 0; i < points; i++) {
			if (score - 1 >= 0) {
				units [score - 1].GoToNormal();
				score--;
			} else if (score > -units.Length) {
				units [units.Length + score - 1].GoToSad ();
				score--;
			}
		}
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.P)) {
			AddPoints (1);
		}
		if (Input.GetKeyDown (KeyCode.O)) {
			AddPoints (2);
		}
		if (Input.GetKeyDown (KeyCode.M)) {
			RemovePoints (1);
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			RemovePoints (2);
		}
	}
}
