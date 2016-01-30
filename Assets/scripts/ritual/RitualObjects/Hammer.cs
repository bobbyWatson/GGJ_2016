using UnityEngine;
using System.Collections;

public class Hammer : RitualObject {


	public override string objectName() {
		return "Hammer";
	}

	public override ActionPlace getBestPlace() {
		return GameManager.singleton.GetActionPlaceByName("Slave");
	}

}
