using UnityEngine;
using System.Collections;

public class Chain : RitualObject {

	public override string objectName() {
		return "Chain";
	}

	public override ActionPlace getBestPlace() {
		return GameManager.singleton.GetActionPlaceByName("Stoup"); 
	}
}
