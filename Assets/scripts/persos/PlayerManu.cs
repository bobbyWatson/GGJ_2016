using UnityEngine;
using System.Collections;

public partial class Player : MonoBehaviour {

	public RitualObject ritualObject; // current object in hands
	public Generator generatorInRange; // current closest generator of ritual objects
	public ActionPlace actionPlace; // current closest action place

	private static float grabRange = 50.0f;
	private static float useRange = 50.0f;

	void AwakeManu (){

	}

	void StartManu(){

	}

	void FixedUpdateManu(){

	}

	void UpdateManu(){

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
		GameManager.singleton.temporaryUItext.text = this.GetPlayerActionsInfo();
		if (Input.GetAxis("DownAction") > 0.5f) {

			if (this.ritualObject==null && this.generatorInRange != null) {
				// grab object from generator
				GameObject obj = this.generatorInRange.Generate();
				this.ritualObject = obj.GetComponent<RitualObject> ();
				this.ritualObject.pickUpPosition = this.ritualObject.transform.position;
				obj.transform.SetParent (this.transform);
				GameManager.singleton.currentStep.ritualObject = this.ritualObject.objectName ();
			}

			if (this.ritualObject != null && this.actionPlace != null) {
				this.ritualObject.Action ();
				GameManager.singleton.currentStep.actionPlace = this.actionPlace.gameObject.name; 
				GameManager.singleton.startStep ();
			}
		}
	}

	public Generator getGeneratorInRange() {
		Vector3 handsPosition = this.mTransform.position + new Vector3 (0f, 25f, 0f);
		Generator gen = GameManager.singleton.GetGenerator (handsPosition, grabRange);
		return gen; // may be null
	}

	public ActionPlace getActionPlaceInRange() {
		Vector3 handsPosition = this.mTransform.position + new Vector3 (0f, 25f, 0f);
		ActionPlace ap = GameManager.singleton.GetActionPlace (handsPosition, useRange);
		return ap; // may be null
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
		} else if(this.actionPlace!=null) {
			s.Append (this.ritualObject.ActionInfo ());
		}
		s.AppendLine ();

		s.Append ("Score: ");
		if (this.ritualObject != null) {
			s.Append(this.ritualObject.getObjectiveScore());
		} 
		s.AppendLine ();


		return s.ToString ();
	}
}
