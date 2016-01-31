using UnityEngine;
using System.Collections;

public class ScoreUnit : MonoBehaviour {

	Animator animator;

	void Awake(){
		animator = GetComponent<Animator> ();
	}

	IEnumerator Start(){
		yield return new WaitForSeconds(Random.Range(0.2f,1.5f));
		animator.SetTrigger ("Start");
	}

	public void GoToHappy(){
		animator.SetTrigger ("Happy");
	}

	public void GoToSad(){
		animator.SetTrigger ("Sad");
	}

	public void GoToNormal(){
		animator.SetTrigger ("Normal");
	}
}
