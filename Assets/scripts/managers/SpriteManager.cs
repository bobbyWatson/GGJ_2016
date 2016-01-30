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

	private List<Transform> sprites;

	void Start(){
		GetGoodSprites ();
	}

	void GetGoodSprites(){
		sprites = new List<Transform> ();
		GameObject[] objects = GameObject.FindGameObjectsWithTag ("ChangeIndexSprite");
		foreach (GameObject o in Object) {
			sprites.Add (o.transform);
		}
	}

	public void SetSpritesIndex (Rect playerPos){

	}
}
