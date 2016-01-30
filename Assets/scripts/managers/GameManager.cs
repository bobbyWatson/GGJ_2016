using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static GameManager singleton;

	public List<RitualObject> ritualObjects;
	public List<RitualSpot> ritualSpots;

	void Awake () {
		if (singleton != null) {
			Debug.LogWarning ("Attempt to create a second GameManager. New one will be ignored.");
			Destroy (this.gameObject);
			return;
		} 

		singleton = this;
		DontDestroyOnLoad (singleton);
	}

	// Update is called once per frame
	void Update () {
	    
	}

}
