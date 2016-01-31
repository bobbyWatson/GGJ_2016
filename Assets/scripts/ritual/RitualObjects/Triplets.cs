using UnityEngine;
using System.Collections.Generic;

public class Triplets {

	public static string[] getActionVerbs(string ritualObject, string actionPlace) {

		foreach (ActionName an in GameManager.singleton.actionNames) {
			if (an.ritualObject == ritualObject && an.ritualPlace == actionPlace) {
				return new string[3]{an.leftActionName, an.upActionName, an.rightActionName};
			}
		}

		// placeholder when not configured
		return new string[3] { "leftAction", "upAction", "rightAction"};
	}

	public static string getActionName(string ritualObject, string actionPlace, PlayerInput input) {
		string[] actionNames = getActionVerbs (ritualObject, actionPlace);
		int verbIdx = input == PlayerInput.Left ? 0 : (input == PlayerInput.Up ? 1 : 2);
		return actionNames [verbIdx];
	}


}

[System.Serializable]
public class ActionName{
	public string ritualObject;
	public string ritualPlace;

	public string leftActionName;
	public string rightActionName;
	public string upActionName;

}
