using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

	public GameObject ritualObjectPrefab;
	public static float generateDistance = 50f;

	public GameObject Generate() {
		Vector3 pos = GameManager.singleton.player.transform.position;
		GameObject rO = (GameObject) Instantiate(ritualObjectPrefab, pos, Quaternion.identity);
		return rO;
	}

	void Start () {}
	
	void Update () {}
}
