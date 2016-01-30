using UnityEngine;
using System.Collections;

public class Step {

	public string ritualObject; // the object that was grabbed
	public string actionPlace; // where the object was used
	public float startTime;
	public float endTime;

	public string ToString() {
		return "ritualObject:" + ritualObject + " actionPlace:" + actionPlace + " time:" + (endTime - startTime)+"s";
	}

}
