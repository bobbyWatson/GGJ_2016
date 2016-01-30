﻿using UnityEngine;
using System.Collections;

public class Candle : RitualObject {



	public override string objectName() {
		return "Candle";
	}

	public override ActionPlace getBestPlace() {
		return GameManager.singleton.actionPlaces[0]; // fire place
	}

	public override void Action() {
		// use will destroy the object
		Destroy(this.gameObject);
		GameManager.singleton.player.ritualObject = null;
		// TODO: other effects
	}

	public override string ActionInfo() {
		if (GameManager.singleton.player.actionPlace != null) {
			return "Use Candle in " + GameManager.singleton.player.actionPlace.gameObject.name;

		}
		return "";
	}

}
