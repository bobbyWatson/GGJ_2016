using UnityEngine;
using System.Collections;

public partial class Player : MonoBehaviour {

	public RitualObject ritualObject; // current object in hands

	private static float grabRange = 100.0f;

	void AwakeManu (){

	}

	void StartManu(){

	}

	void FixedUpdateManu(){

	}

	void UpdateManu(){
		if (Input.GetAxis("DownAction") > 0.5f && ritualObject==null) {
			this.ritualObject = this.getGrabableObject ();

			if (this.ritualObject != null) {
				Debug.Log ("Player can grab " + this.ritualObject.objectName);
				this.ritualObject.gameObject.transform.SetParent (this.mTransform);

			} else {
				Debug.Log ("Player cannot grab anything");
			}
		}

		if (Input.GetAxis("UpAction") > 0.5f && ritualObject!=null) {
			Debug.Log ("UpAction: Dropping "+this.ritualObject.objectName);
			this.ritualObject.transform.SetParent (GameManager.singleton.propsDefaultContainer);
			this.ritualObject = null;
		}

		if (Input.GetAxis("LeftAction") > 0.5f ) {
			Debug.Log ("LeftAction");
		}

		if (Input.GetAxis("RightAction") > 0.5f ) {
			Debug.Log ("RightAction");
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
}
