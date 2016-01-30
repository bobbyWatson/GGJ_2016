using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static GameManager singleton;


	public List<Generator> ritualObjectsGenerators;
	public List<ActionPlace> actionPlaces;

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

		singleton.ritualObjectsGenerators = new List<Generator> ();
		foreach(GameObject genGO in GameObject.FindGameObjectsWithTag("GENERATOR")) {
			Generator gen = genGO.GetComponent<Generator>();
			singleton.ritualObjectsGenerators.Add(gen);
		}
		Debug.Log ("Game Manager generators found:" + singleton.ritualObjectsGenerators.Count);

		singleton.actionPlaces = new List<ActionPlace> ();
		foreach(GameObject apGO in GameObject.FindGameObjectsWithTag("ACTION_PLACE")) {
			ActionPlace ap = apGO.GetComponent<ActionPlace>();
			singleton.actionPlaces.Add(ap);
		}
		Debug.Log ("Game Manager action places found:" + singleton.actionPlaces.Count);
	}

	public Generator GetGenerator(Vector3 playerPos, float grabRadius) {
		Generator closestGen = null;
		float minDistance = grabRadius;

		foreach (Generator gen in ritualObjectsGenerators) {
			if (gen != null && gen.gameObject != null && gen.gameObject.transform != null) {
				Transform t = gen.gameObject.transform;
				float distance = Vector3.Distance (t.position, playerPos);
				if (distance <= minDistance) {
					closestGen = gen;
					minDistance = distance;
				}
			}
		}
		return closestGen;
	}

	public ActionPlace GetActionPlace(Vector3 playerPos, float grabRadius) {
		ActionPlace closestAP = null;
		float minDistance = grabRadius;

		foreach (ActionPlace ap in actionPlaces) {
			if (ap != null && ap.gameObject != null && ap.gameObject.transform != null) {
				Transform t = ap.gameObject.transform;
				float distance = Vector3.Distance (t.position, playerPos);
				if (distance <= minDistance) {
					closestAP = ap;
					minDistance = distance;
				}
			}
		}
		return closestAP;
	}

	// Update is called once per frame
	void Update () {

	}

}
