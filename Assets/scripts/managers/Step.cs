using UnityEngine;
using System.Collections;

public class Step {

	public string ritualObject; // the object that was grabbed
	public string actionPlace; // where the object was used
	public PlayerInput playerInput; // what was done with the object and the place

	public float startTime;
	public float endTime;

	public string ToString() {
		return "ritualObject:" + ritualObject + " actionPlace:" + actionPlace + " time:" + (endTime - startTime)+"s";
	}

	public Step() {
	}

	public Step(string ritualObject, string actionPlace, PlayerInput playerInput) {
		this.ritualObject = ritualObject;
		this.actionPlace = actionPlace;
		this.playerInput = this.playerInput;
	}

	/*
	 * Pick Bon objet : +2

Pick bad objet : 0

Bon lieu + Bon action : +6  (Total : 8points)

Bon lieu, Mauvaise action :+2 (Total : 4 points)

Mauvais lieu, Bon objet : 0    (Total : 2 points)

Bon lieu, Mauvais objet : 0      (Total, 0 points)

Mauvais lieu, mauvais objet, : -­6 (Total : ­6 points)

Toutes  les 4 secondes inactives : ­ 5*/
	
	public static int score(Step actual, Step opt) {
		
		bool place = actual.actionPlace == opt.ritualObject;
		bool action = actual.playerInput == opt.playerInput;
		bool obj = actual.ritualObject == opt.ritualObject;

		int score = obj ? 2 : 0;

		if (place && action) {
			score += 6;
		} else if (place && !action) {
			score += 2;
		} else { // !place
			score += action ? 0 : -6;
		}

		int totalTime = (int) (actual.endTime - actual.startTime);
		score -= (totalTime / 4) * 5; 

		return score;
	}

	public static int currentStepScore(Step current, Step opt) {

		bool obj = current.ritualObject == opt.ritualObject;

		int score = obj ? 2 : 0;
		int totalTime = (int) (Time.time - current.startTime);
		score -= (totalTime / 4) * 5; 

		return score;
	}
}
