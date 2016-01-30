using UnityEngine;
using System.Collections;

public partial class Player : MonoBehaviour {

	public RitualObject ritualObject; // current object in hands
	public RitualObject grabableObject; // current object that we could grab

	private static float grabRange = 30.0f;

	void AwakeManu (){

	}

	void StartManu(){

	}

	void FixedUpdateManu(){

	}

	void UpdateManu(){

		// Update grabableObject
		if (this.ritualObject == null) {
			this.grabableObject = this.getGrabableObject ();
		} else {
			this.grabableObject = null;
		}

		// Update UI
		GameManager.singleton.temporaryUItext.text = this.GetPlayerActionsInfo();

		if (Input.GetAxis("DownAction") > 0.5f) {

			if (ritualObject != null) {
				ritualObject.DownAction ();
			} else if(this.grabableObject!=null) {
			    // grab object closest object in range
				this.ritualObject = this.grabableObject;
				this.ritualObject.pickUpPosition = this.ritualObject.transform.position;
				this.grabableObject = null;
				this.ritualObject.gameObject.transform.SetParent (this.mTransform);
			} else {
				Debug.Log ("Player cannot grab anything");
			}
		}

		if (Input.GetAxis("UpAction") > 0.5f && ritualObject!=null) {
			ritualObject.UpAction ();
		}

		if (Input.GetAxis("LeftAction") > 0.5f && ritualObject!=null) {
			ritualObject.LeftAction ();
		}

		if (Input.GetAxis("RightAction") > 0.5f && ritualObject!=null) {
			ritualObject.RightAction ();
		}


	}

	public RitualObject getGrabableObject() {
		Vector3 handsPosition = this.mTransform.position + new Vector3 (0f, 25f, 0f);
		Transform t = SpriteManager.Instance.GetGrabableObject (handsPosition, grabRange);
		if (t != null) {
			return t.gameObject.GetComponent<RitualObject> ();
		}
		return null;
	}

	public string GetPlayerActionsInfo() {
		System.Text.StringBuilder s = new System.Text.StringBuilder ();

		s.Append ("Object: ");
		s.Append(this.ritualObject==null ? "none" : this.ritualObject.objectName());
		s.AppendLine ();

		if (this.ritualObject != null) {
			s.Append ("DownAction: ");
			s.Append (this.ritualObject.DownActionInfo ());
			s.AppendLine ();

			s.Append ("UpAction: ");
			s.Append (this.ritualObject.UpActionInfo ());
			s.AppendLine ();

			s.Append ("LeftAction: ");
			s.Append (this.ritualObject.LeftActionInfo ());
			s.AppendLine ();

			s.Append ("RightAction: ");
			s.Append (this.ritualObject.RightActionInfo ());
			s.AppendLine ();
		} else {
			s.Append ("DownAction: ");
			if (this.grabableObject != null) {
				s.Append ("Grab " + this.grabableObject.name);
			}
			s.AppendLine ();
			s.Append ("UpAction: "); s.AppendLine ();
			s.Append ("LeftAction: "); s.AppendLine ();
			s.Append ("RightAction: "); s.AppendLine ();
		}

		s.Append ("Score: ");

		s.Append(this.ritualObject==null ? "" : ""+this.ritualObject.getObjectiveScore());
		s.AppendLine ();

		return s.ToString ();
	}
}
