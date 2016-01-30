using UnityEngine;
using System.Collections;

public class GroupSpot : MonoBehaviour {

	public int ID;
	public Transform[] CharactersSpots;

	void Awake(){
		CharactersSpots = GetComponentsInChildren<Transform> ();
	}
}
