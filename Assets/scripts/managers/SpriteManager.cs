using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpriteManager : MonoBehaviour {

	private static SpriteManager _instance;
	public static SpriteManager Instance{
		get{
			if (_instance == null)
				_instance = FindObjectOfType<SpriteManager> ();
			return _instance;
		}
	}

	private List<Transform> meubles;
	private List<Transform> props;

	void Start(){
		GetGoodSprites ();
	}

	void GetGoodSprites(){
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
				float index = 0;
				if ((t.position + Vector3.down * t.localScale.y / 2).y < (playerPos.position + Vector2.down * playerPos.height /2).y) {
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
}
