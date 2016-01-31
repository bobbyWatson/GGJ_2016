using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public int score = 0;
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

	public void AddGenPoints(int points) {
		if (points > 0) {
			this.AddPoints (points);
		} else if (points < 0) {
			this.RemovePoints (-points);
		}
	}

	private float timePassed;
	public float timeInterval;
	public int pointsLostPerInterval = 1;

	IEnumerator Start() {
		while (true) {
			yield return null;
			timePassed += Time.deltaTime;
			if (timePassed >= timeInterval) {
				timePassed -= timeInterval;
				RemovePoints(pointsLostPerInterval);
			}
		}
	}

	public void resetTimer() {
		timePassed = 0f;
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
