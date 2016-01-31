using UnityEngine;
using System.Collections;

abstract public class RitualObject : MonoBehaviour {

	public Vector3 pickUpPosition; // position where the object was picked up

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
    
	public void Action(PlayerInput playerInput) { // action when player has object and presses Action (depends on position)
		
		Destroy(this.gameObject);
		Player player = GameManager.singleton.player;
		player.ritualObject = null;

		StartCoroutine(player.animateAction(player.actionPlace, playerInput));

	}

	public string ActionInfo(PlayerInput playerInput) // tells what the action will do, but does nothing
	{
		if (GameManager.singleton.player.actionPlace != null) {

			string actionPlace = GameManager.singleton.player.actionPlace.gameObject.name;
			string ritualObject = this.objectName ();
			string[] verbs = Triplets.getActionVerbs (ritualObject, actionPlace); 

			int verbIdx = 0; // left
			if(playerInput==PlayerInput.Up) verbIdx=1;
			if(playerInput==PlayerInput.Right) verbIdx=2;

		//#return ritualObject + " " + verbs[verbIdx] + " " + actionPlace;
			return verbs[verbIdx];
		}

		return "";
	}

}
