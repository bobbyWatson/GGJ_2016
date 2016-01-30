using UnityEngine;
using System.Collections;

public partial class Player : MonoBehaviour {

	public RitualObject ritualObject; // current object in hands

	private static float grabRange = 200.0f;

	void AwakeManu (){

	}

	void StartManu(){

	}

	void FixedUpdateManu(){

	}

	void UpdateManu(){
		if (Input.GetKeyDown ("down")) {
			RitualObject rO = this.getGrabableObject ();
			if (rO != null) {
				Debug.Log ("Player can grab " + rO.objectName);
			} else {
				Debug.Log ("Player cannot grab anything");
			}
		}
	}

	/**
	 * Returns null if no object is within grabRange
	 * Returns the closest grabable object
	 */
	public RitualObject getGrabableObject() {
		Transform t = SpriteManager.Instance.GetGrabableObject (this.mTransform.position, grabRange);
		if (t != null) {
			return t.gameObject.GetComponent<RitualObject> ();
		}
		return null;
	}
}
