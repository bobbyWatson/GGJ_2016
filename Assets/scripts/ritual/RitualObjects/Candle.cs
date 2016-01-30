using UnityEngine;
using System.Collections;

public class Candle : RitualObject {

	public GameObject candleSpot;
	public GameObject fireSpot;
	public bool litUp = false;
	public float lightUpDist = 30.0f;

	public override string objectName() {
		return "Candle";
	}

	public override Vector3 getIdealPosition() {
		if (litUp) {
			return candleSpot.transform.position;
		} else {
			return fireSpot.transform.position;
		}
	}

	public override void UpAction() {
		// drop the calice
		this.transform.SetParent (GameManager.singleton.propsDefaultContainer);
		GameManager.singleton.player.ritualObject = null;

	}
	public override string UpActionInfo() {
		return "Drop the Candle";
	}

	public override void DownAction() {
	}
	public override string DownActionInfo() {
		return "";
	}

	public override void LeftAction() {
	}
	public override string LeftActionInfo() {
		return "";
	}

	public override void RightAction() {
		if (canLightUp ()) {
			Debug.Log ("Lighting up candle");
			litUp = true;
			GetComponent<SpriteRenderer>().color = new Color(1f, .6f, 0f); // orange
		}
	}
	public override string RightActionInfo() {
		if (canLightUp()) {
			return "Light up candle";
		}
		return "";
	}

	public bool canLightUp() {
		if(litUp==false) {
			if(Vector3.Distance(fireSpot.transform.position, this.transform.position) < lightUpDist) {
				return true;
			}
		}
		return false;
	}

}
