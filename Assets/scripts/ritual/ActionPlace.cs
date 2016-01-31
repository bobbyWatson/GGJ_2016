using UnityEngine;
using System.Collections;

public class ActionPlace : MonoBehaviour {

	public IEnumerator animateObject (string action) {
		GetComponent<Animator> ().SetTrigger (action);
		yield return null;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
