using UnityEngine;
using System.Collections;

abstract public class RitualObject : MonoBehaviour {

	public Vector3 pickUpPosition;

	public abstract string objectName();
	public abstract ActionPlace getBestPlace(); // the best place to "use" the object

	public Vector3 getIdealPosition() {
		return getBestPlace().gameObject.transform.position;
	}

	public float getObjectiveScore() {

		float distToOpt = Vector3.Distance (getIdealPosition(), this.transform.position);
		float initDistToOpt = Vector3.Distance(this.pickUpPosition, getIdealPosition());

		float s = (initDistToOpt - distToOpt) / initDistToOpt;
		return UnityEngine.Mathf.Max (s, -1f);
	}
    
	public abstract void Action(); // action when player has object and presses Action (depends on position) 
	public abstract string ActionInfo(); // tells what the action will do, but does nothing

}
