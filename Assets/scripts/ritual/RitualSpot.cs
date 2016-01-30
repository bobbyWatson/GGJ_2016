using UnityEngine;
using System.Collections;

public class RitualSpot : MonoBehaviour {

	private BoxCollider2D mBoxCollider2d;

	void Awake() {
		mBoxCollider2d = GetComponent<BoxCollider2D> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Player player = other.gameObject.GetComponent<Player> ();
			player.ritualSpot = this;
			Debug.Log ("entered spot");
		}
	}





}
