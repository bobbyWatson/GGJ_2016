using UnityEngine;
using System.Collections;

public class Calice : RitualObject {

	public override string objectName() {
		return "Calice";
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
	}
	public override string LeftActionInfo() {
		return "";
	}

	public override void RightAction() {
	}
	public override string RightActionInfo() {
		return "";
	}

}
