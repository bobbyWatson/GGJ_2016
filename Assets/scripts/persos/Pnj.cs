using UnityEngine;
using System.Collections;

public class Pnj : MonoBehaviour {

	private const float REPLICA_DURATION = 1.5f;
	private bool stop = false;
	private GameObject bulle;

	public void StartReplica(Replica replica){
		GameObject o = new GameObject ("bulle") as GameObject;
		o.transform.SetParent (transform);
		o.transform.position = transform.position + Vector3.up * 120;
		SpriteRenderer sr = o.AddComponent<SpriteRenderer> ();
		sr.sprite = PreparationManager.Instance.bulleSprite;
		bulle = o;

		Debug.Log (name + " is saying : " + replica.text);
		StartCoroutine (EndOfReplica (replica));
	}

	IEnumerator EndOfReplica(Replica replica){
		yield return new WaitForSeconds (REPLICA_DURATION);
		Destroy (bulle);
		if (!stop)
			replica.Finished ();
		else
			stop = false;		
	}

	public void StopReplica(){
		stop = true;
	}
}
