using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	
	public ActionName[] actionNames;

	public static GameManager singleton;

	public ScoreManager scoreManager;

	//the perfect!
	public List<Step> optimalSteps;

	public List<Step> GenerateOptimalsSteps(){
		
		List<Step> result = new List<Step> ();
		result.Add (new Step ("Candle", "Statue", PlayerInput.Left)); // offrir
		result.Add (new Step ("Knife", "Statue", PlayerInput.Up)); // decapiter
		result.Add (new Step ("Hammer", "Stoup", PlayerInput.Right)); // frapper
		result.Add (new Step ("Pineapple", "Stoup", PlayerInput.Left)); // benir
		result.Add (new Step ("Knife", "Poney", PlayerInput.Up)); // licorne
		result.Add (new Step ("Pineapple", "Poney", PlayerInput.Up)); // violer
		result.Add (new Step ("Blood", "Stoup", PlayerInput.Up)); // melanger
		result.Add (new Step ("Chain", "Stoup", PlayerInput.Up)); // rester perplexe

		return result;
	}

	public Step currentOptimalStep() {
		int numStep = steps.Count;
		return optimalSteps [numStep];
	}

	public int PlayerScore() {
		/*
		int score = 0;
		for (int i = 0; i < steps.Count; i++) {
			score += Step.score (steps [i], optimalSteps [i]);
		}

		if(steps.Count < optimalSteps.Count) { // Add current Step score
		    score += Step.currentStepScore(currentStep, optimalSteps[steps.Count]);
		}
		return score;
		*/
		return scoreManager.score;
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

		//singleton.player = GameObject.FindWithTag ("Player").GetComponent<Player> ();
		singleton.player.inSecondPhase = true;

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
		this.optimalSteps = this.GenerateOptimalsSteps ();
		this.startNewStep ();

		//foreach (Step step in optimalSteps) {
		//	Debug.Log (step.ToString());
		//}

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

	public ActionPlace GetClosestActionPlace(Vector3 playerPos, float grabRadius) {
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

	public ActionPlace GetActionPlaceByName(string name){
		if (name == "Statue") {
			return this.actionPlaces [0];
		}
		if (name == "Slave") {
			return this.actionPlaces [1];
		}
		if (name == "Poney") {
			return this.actionPlaces [2];
		}
		if (name == "Stoup") {
			return this.actionPlaces [3];
		}
		return null;
	}



	// Update is called once per frame
	void Update () {

	}

	public void startNewStep() {
		if (currentStep != null) {
			currentStep.endTime = Time.time;
			steps.Add (currentStep);
			Debug.Log ("Step ended:" + currentStep.ToString());
		}

		// check if end of game:
		if (steps.Count == optimalSteps.Count) {

			if (scoreManager.score >= scoreManager.victoryScore) {
				PlayerPrefs.SetString ("state", "victory");
			} else {
				PlayerPrefs.SetString ("state", "defeat");
			}
				
			SceneManager.LoadScene ("End");
		}

		// game not ended
		currentStep = new Step ();
		currentStep.startTime = Time.time;
	}

}

public enum PlayerInput {Up, Down, Left, Right};