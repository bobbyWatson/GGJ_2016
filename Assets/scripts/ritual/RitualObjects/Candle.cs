using UnityEngine;
using System.Collections;

public class Candle : RitualObject {
	
	public override string objectName() {
		return "Candle";
	}

	public override ActionPlace getBestPlace() {
		return GameManager.singleton.GetActionPlaceByName("Stoup"); 
	}



}
