using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static GameManager singleton;


	public List<RitualObject> ritualObjects;
	public List<RitualSpot> ritualSpots;
	public Transform propsDefaultContainer;
	public Player player;

	public UnityEngine.UI.Text temporaryUItext;

	void Awake () {
		if (singleton != null) {
			Debug.LogWarning ("Attempt to create a second GameManager. New one will be ignored.");
			Destroy (this.gameObject);
			return;
		} 

		singleton = this;
		DontDestroyOnLoad (singleton);
		singleton.propsDefaultContainer = GameObject.FindWithTag("PROP_CONTAINER").transform;
		singleton.temporaryUItext =  GameObject.Find("TemporaryText").GetComponent<UnityEngine.UI.Text>();
		singleton.player = GameObject.FindWithTag ("Player").GetComponent<Player> ();
	}

	// Update is called once per frame
	void Update () {
	    
	}

}
