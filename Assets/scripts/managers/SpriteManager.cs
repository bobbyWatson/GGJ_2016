using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteManager : MonoBehaviour {


	private static SpriteManager _instance;
	public static SpriteManager Instance{
		get{
			if (_instance == null) {
				_instance = FindObjectOfType<SpriteManager> ();
				if (_instance == null) {
					GameObject o = new GameObject ("spriteManager");
					_instance = o.AddComponent<SpriteManager> ();
				}
			}
			return _instance;
		}
	}

	private List<Transform> meubles;
	private List<Transform> props;

	void Awake(){
		GetGoodSprites ();
	}

	public void AddProp(Transform prop){
		props.Add (prop);
	}

	public void GetGoodSprites(){
		meubles = new List<Transform> ();
		props = new List<Transform> ();
		GameObject[] objects = GameObject.FindGameObjectsWithTag ("MEUBLE");
		foreach (GameObject o in objects) {
			meubles.Add (o.transform);
		}
		objects = GameObject.FindGameObjectsWithTag ("PROP");
		foreach (GameObject o in objects) {
			props.Add (o.transform);
		}
	}

	public void SetSpritesIndex (Rect playerPos){
		foreach (Transform t in meubles) {
			if (t != null) {
				Sprite tx = t.GetComponent<SpriteRenderer> ().sprite;
				float index = 0;
				if ((t.position + Vector3.down * t.localScale.y / 2 * tx.bounds.size.y).y < (playerPos.position + Vector2.down * playerPos.height /2).y) {
					t.position = new Vector3 (t.position.x, t.position.y, -1);
				} else {
					t.position = new Vector3 (t.position.x, t.position.y, 2);
				}
			}
		}
		foreach (Transform t in props) {
			if (t != null) {
				float index = 0;
				if ((t.position + Vector3.down * t.localScale.y / 2).y < (playerPos.position + Vector2.down * playerPos.height /2).y) {	
					t.position = new Vector3 (t.position.x, t.position.y, -2);
				} else {
					t.position = new Vector3 (t.position.x, t.position.y, 1);
				}
			}
		}
	}

	/**
	 * Returns the closest object that can be grabbed by the player (if any)
	 * Returns null otherwise
	 * */
	public Transform GetGrabableObject(Vector3 playerPos, float grabRadius) {
		Transform closestGrabable = null;
		float minDistance = grabRadius;

		foreach (Transform t in props) {
			if (t != null) {
				float distance = Vector3.Distance (t.position, playerPos);
				if (distance <= minDistance) {
					closestGrabable = t;
					minDistance = distance;
				}
			}
		}
		return closestGrabable;
	}
}
