using UnityEngine;
using System.Collections;

public class Blood : RitualObject {

	public override string objectName() {
		return "Blood";
	}

	public override ActionPlace getBestPlace() {
		return GameManager.singleton.GetActionPlaceByName("Stoup"); 
	}
}
