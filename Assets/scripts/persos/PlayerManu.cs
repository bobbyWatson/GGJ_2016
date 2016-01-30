using UnityEngine;
using System.Collections;

public partial class Player : MonoBehaviour {

	public RitualObject ritualObject; // current object in hands
	public RitualObject grabableObject; // current object that we could grab

	private static float grabRange = 100.0f;

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

		if (Input.GetAxis("DownAction") > 0.5f && this.grabableObject!=null) {
			if (this.grabableObject != null) {
				this.ritualObject = this.grabableObject;
				this.grabableObject = null;
				this.ritualObject.gameObject.transform.SetParent (this.mTransform);
			} else {
				Debug.Log ("Player cannot grab anything");
			}
		}

		if (Input.GetAxis("UpAction") > 0.5f && ritualObject!=null) {
			Debug.Log ("UpAction: Dropping "+this.ritualObject.objectName());
			this.ritualObject.transform.SetParent (GameManager.singleton.propsDefaultContainer);
			this.ritualObject = null;
		}

		if (Input.GetAxis("LeftAction") > 0.5f && ritualObject!=null) {
			ritualObject.LeftAction ();
		}

		if (Input.GetAxis("RightAction") > 0.5f && ritualObject!=null) {
			ritualObject.RightAction ();
		}


	}

	public RitualObject getGrabableObject() {
		Vector3 handsPosition = this.mTransform.position + new Vector3 (0f, 50f, 0f);
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

		s.Append ("DownAction: ");
		if (this.grabableObject != null) {
			s.Append ("Grab "+this.grabableObject.name);
		}
		s.AppendLine ();

		s.Append ("UpAction: ");
		if (this.ritualObject != null) {
			s.Append ("Drop "+this.ritualObject.name);
		}
		s.AppendLine ();

		s.Append ("LeftAction:");
		s.AppendLine ();
		s.Append ("RightAction:");
		s.AppendLine ();

		return s.ToString ();
	}
}
