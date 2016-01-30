using UnityEngine;
using System.Collections;

public class Hammer : RitualObject {


	public override string objectName() {
		return "Hammer";
	}

	public override ActionPlace getBestPlace() {
		return GameManager.singleton.actionPlaces[2]; // slave
	}

	public override void Action() {
		// use will destroy the object
		Destroy(this.gameObject);
		GameManager.singleton.player.ritualObject = null;
		// TODO: other effects
	}

	public override string ActionInfo() {
		if (GameManager.singleton.player.actionPlace != null) {
			return "Use Hammer in " + GameManager.singleton.player.actionPlace.gameObject.name;

		}
		return "";
	}

}
