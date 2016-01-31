using UnityEngine;
using System.Collections;

public class Knife : RitualObject {

	public override string objectName() {
		return "Knife";
	}

	public override ActionPlace getBestPlace() {
		return GameManager.singleton.GetActionPlaceByName("Statue"); 
	}
}
