using UnityEngine;
using System.Collections;

public class Calice : RitualObject {

	public GameObject caliceSpot;
	public bool containsLiquid = true;

	public override string objectName() {
		return "Calice";
	}

	public override Vector3 getIdealPosition() {
		return caliceSpot.transform.position;
	}

	
	public override void UpAction() {
		// drop the calice
		this.transform.SetParent (GameManager.singleton.propsDefaultContainer);
		GameManager.singleton.player.ritualObject = null;
	}
	public override string UpActionInfo() {
		return "Drop the Calice";
	}

	public override void DownAction() {
	}
	public override string DownActionInfo() {
		return "";
	}

	public override void LeftAction() {
		Debug.Log ("Drunk liquid from calice");
		containsLiquid = false;
		GetComponent<SpriteRenderer>().color = Color.cyan;
	}
	public override string LeftActionInfo() {
		if (containsLiquid) {
			return "Drink liquid in calice";
		} else {
			return "";
		}
	}

	public override void RightAction() {
	}
	public override string RightActionInfo() {
		return "";
	}

}
