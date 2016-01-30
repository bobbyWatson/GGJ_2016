﻿using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static GameManager singleton;

	//the perfect!
	public List<Step> optimalSteps;

	public List<Step> GenerateOptimalsSteps(){
		List<Step> result = new List<Step> ();
		List<string> ritualObjectNames = new List<string>();
		ritualObjectNames.Add("Candle");
		ritualObjectNames.Add("Hammer");
		Random.seed = 17;
		for (int i = 0; i < 8; i++) {
			Step step = new Step ();
			step.actionPlace = this.actionPlaces[Random.Range(0, this.actionPlaces.Count)].gameObject.name;
			step.ritualObject = ritualObjectNames[Random.Range(0, ritualObjectNames.Count)];
			result.Add (step);
		}

		return result;
	}

	public List<Generator> ritualObjectsGenerators;
	public List<ActionPlace> actionPlaces;

	public Transform propsDefaultContainer;
	public Player player;

	public List<Step> steps;
	public Step currentStep;

	public UnityEngine.UI.Text temporaryUItext;

	void Awake () {
		if (singleton != null) {
			Debug.LogWarning ("Attempt to create a second GameManager. New one will be ignored.");
			Destroy (this.gameObject);
			return;
		}

		singleton = this;
		singleton.steps = new List<Step> ();
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

	void Start() {
		this.startStep ();

		this.optimalSteps = this.GenerateOptimalsSteps ();
		foreach (Step step in optimalSteps) {
			Debug.Log (step.ToString());
		}

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

	public void startStep() {
		if (currentStep != null) {
			currentStep.endTime = Time.time;
			steps.Add (currentStep);
			Debug.Log ("Step ended:" + currentStep.ToString());
		}
		currentStep = new Step ();
		currentStep.startTime = Time.time;
	}

}
