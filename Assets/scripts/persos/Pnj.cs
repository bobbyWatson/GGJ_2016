using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pnj : MonoBehaviour {

	private const float REPLICA_DURATION = 3f;
	private bool stop = false;
	private GameObject bulle;

	public void StartReplica(Replica replica){
		GameObject o = new GameObject ("bulle") as GameObject;
		o.transform.SetParent (transform);
		o.transform.position = transform.position + Vector3.up * 50;
		SpriteRenderer sr = o.AddComponent<SpriteRenderer> ();
		sr.sprite = PreparationManager.Instance.bulleSprite;
		sr.color = new Color (1, 1, 1, 0.9f);
		bulle = o;
		GameObject phrase = GameObject.Instantiate (PreparationManager.Instance.PhrasePrefab) as GameObject;
		phrase.transform.SetParent (o.transform);
		phrase.transform.localPosition = PreparationManager.Instance.PhrasePrefab.transform.localPosition;
		phrase.transform.localScale = Vector3.one;
		phrase.GetComponentInChildren<Text> ().text = replica.text;

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
