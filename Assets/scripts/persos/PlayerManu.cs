﻿using UnityEngine;
using System.Collections;

public partial class Player : MonoBehaviour {

	public RitualObject ritualObject; // current object in hands
	public Generator generatorInRange; // current closest generator of ritual objects
	public ActionPlace actionPlace; // current closest action place

	private static float grabRange = 100.0f;
	private static float useRange = 200.0f;

	void AwakeManu (){
	}

	void StartManu(){

	}

	public IEnumerator animateAction(ActionPlace place, PlayerInput input) {

		this.setCantMoveForSeconds (1.5f);

		mCollider.enabled = false;
		Vector3 playerPos = this.mTransform.position;
		mTransform.position = place.gameObject.transform.position;

		string objName = this.ritualObject.objectName();

		animator.SetTrigger ("Action");
		yield return new WaitForSeconds (1f);
		animator.SetTrigger ("EndAction");

		string actionName = Triplets.getActionName (objName, place.gameObject.name, input);

		yield return new WaitForSeconds (1f);
		StartCoroutine(place.animateObject (actionName));

		mTransform.position = playerPos;
		mCollider.enabled = true;
		yield break;
	}

	void FixedUpdateManu(){

	}

	void UpdateManu(){
		if (!inSecondPhase || GameManager.singleton == null) {
			return;
		}
		// Update generatorInRange
		if (this.ritualObject == null) {
			this.generatorInRange = this.getGeneratorInRange ();

		} else {
			this.generatorInRange = null;
		}

		// Update actionPlace
		if (this.ritualObject == null) {
			this.actionPlace = null;
		} else {
			this.actionPlace = this.getActionPlaceInRange();
		}

		// Update UI
		if (GameManager.singleton!=null && GameManager.singleton.temporaryUItext != null) {
			GameManager.singleton.temporaryUItext.text = this.GetPlayerActionsInfo ();
		}

		if (Input.GetAxis("DownAction") > 0.5f) {

			if (this.ritualObject==null && this.generatorInRange != null) {
				// grab object from generator
				GameObject obj = this.generatorInRange.Generate();
				this.ritualObject = obj.GetComponent<RitualObject> ();
				this.ritualObject.pickUpPosition = this.ritualObject.transform.position;
				obj.transform.SetParent (this.transform);
				GameManager.singleton.currentStep.ritualObject = this.ritualObject.objectName ();

				int objScore = Step.scoreObject (GameManager.singleton.currentStep, 
					                             GameManager.singleton.currentOptimalStep());
				GameManager.singleton.scoreManager.AddGenPoints (objScore);

			}

		}

		if (this.ritualObject != null && this.actionPlace != null) {
			bool pressedOther = false;
			PlayerInput playerInput = PlayerInput.Down;

			if (Input.GetAxis ("UpAction") > 0.5f) {
				pressedOther = true;
				playerInput = PlayerInput.Up;
			}

			if (Input.GetAxis ("LeftAction") > 0.5f) {
				pressedOther = true;
				playerInput = PlayerInput.Left;
			}

			if (Input.GetAxis ("RightAction") > 0.5f) {
				pressedOther = true;
				playerInput = PlayerInput.Right;
			}

			if(pressedOther) {
				this.ritualObject.Action (playerInput);


				GameManager.singleton.scoreManager.resetTimer ();

				// update current step info and start next step
				GameManager.singleton.currentStep.actionPlace = this.actionPlace.gameObject.name;
				GameManager.singleton.currentStep.playerInput = playerInput;

				int actionScore = Step.scoreAction (GameManager.singleton.currentStep, GameManager.singleton.currentOptimalStep());
				GameManager.singleton.scoreManager.AddGenPoints (actionScore);

				GameManager.singleton.startNewStep ();
			}
		}

	}

	public Generator getGeneratorInRange() {
		if(this.inSecondPhase && GameManager.singleton != null && GameManager.singleton.ritualObjectsGenerators != null){
		   Vector3 handsPosition = this.mTransform.position + new Vector3 (0f, 25f, 0f);
		   Generator gen = GameManager.singleton.GetGenerator (handsPosition, grabRange);
		   return gen; // may be null
		} 
		return null;
	}

	public ActionPlace getActionPlaceInRange() {
		if(this.inSecondPhase && GameManager.singleton != null && GameManager.singleton.ritualObjectsGenerators != null){
		   Vector3 handsPosition = this.mTransform.position + new Vector3 (0f, 25f, 0f);
		   ActionPlace ap = GameManager.singleton.GetClosestActionPlace (handsPosition, useRange);
		   return ap; // may be null
		}
		return null;
	}


	public string GetPlayerActionsInfo() {
		System.Text.StringBuilder s = new System.Text.StringBuilder ();

		s.Append ("Object: ");
		s.Append(this.ritualObject==null ? "none" : this.ritualObject.objectName());
		s.AppendLine ();

		s.Append ("DownAction: ");
		if (this.ritualObject == null) {
			if (this.generatorInRange!=null) {
				s.Append("Grab "+this.generatorInRange.gameObject.name);
			}
		}
		s.AppendLine ();

		s.Append("UpAction: ");
		if(this.actionPlace!=null) {
			s.Append (this.ritualObject.ActionInfo (PlayerInput.Up));
		}
		s.AppendLine ();

		s.Append ("LeftAction: ");
		if(this.actionPlace!=null) {
			s.Append (this.ritualObject.ActionInfo (PlayerInput.Left));
		}
		s.AppendLine ();

		s.Append ("RightAction: ");
		if(this.actionPlace!=null) {
			s.Append (this.ritualObject.ActionInfo (PlayerInput.Right));
		}
		s.AppendLine ();

		s.Append ("Score: ");
		s.Append(GameManager.singleton.PlayerScore());
		s.AppendLine ();


		return s.ToString ();
	}



}

