using UnityEngine;
using System.Collections;

abstract public class RitualObject : MonoBehaviour {

	public abstract string objectName();
	public Vector3 pickUpPosition;

	public abstract Vector3 getIdealPosition();

	public float getObjectiveScore() {

		float distToOpt = Vector3.Distance (getIdealPosition(), this.transform.position);
		float initDistToOpt = Vector3.Distance(this.pickUpPosition, getIdealPosition());

		float s = (initDistToOpt - distToOpt) / initDistToOpt;
		return UnityEngine.Mathf.Max (s, -1f);
	}


	public abstract void UpAction(); // action when player has object and presses UpAction (depends on position) 
	public abstract string UpActionInfo(); // tells what the action will do, but does nothing

	public abstract void DownAction();
	public abstract string DownActionInfo();

	public abstract void LeftAction();
	public abstract string LeftActionInfo();

	public abstract void RightAction();
	public abstract string RightActionInfo();

}
