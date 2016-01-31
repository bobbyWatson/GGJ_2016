using UnityEngine;
using System.Collections;

public class ActionPlace : MonoBehaviour {

	public IEnumerator animateObject (string action) {
		AnimatorControllerParameter[] _params =  GetComponent<Animator>().parameters;
		bool found = false;
		foreach (AnimatorControllerParameter param in _params) {
			if (param.name == action)
				found = true;
		}
		if( found)
			GetComponent<Animator> ().SetTrigger (action);
		else
			GetComponent<Animator> ().SetTrigger ("Root");
			
		yield return null;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
