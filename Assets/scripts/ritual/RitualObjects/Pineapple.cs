using UnityEngine;
using System.Collections;

public class Pineapple : RitualObject {

	public override string objectName() {
		return "Pineapple";
	}

	public override ActionPlace getBestPlace() {
		return GameManager.singleton.GetActionPlaceByName("Poney"); 
	}
}
