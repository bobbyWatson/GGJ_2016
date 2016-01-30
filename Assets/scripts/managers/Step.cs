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

}
