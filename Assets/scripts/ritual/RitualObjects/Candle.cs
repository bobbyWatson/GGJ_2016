using UnityEngine;
using System.Collections;

public class Candle : RitualObject {

	public override string objectName() {
		return "Candle";
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
	}
	public override string RightActionInfo() {
		return "";
	}

}
