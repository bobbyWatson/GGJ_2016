using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class parallax : MonoBehaviour {

	public GameObject cinematique_front;
	public GameObject cinematique_middle;
	public GameObject cinematique_back;
	public GameObject cinematique_sky;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		cinematique_front = GameObject.FindGameObjectWithTag ("front");
		cinematique_middle = GameObject.FindGameObjectWithTag ("middle");
		cinematique_back = GameObject.FindGameObjectWithTag ("back");
		cinematique_sky = GameObject.FindGameObjectWithTag ("sky");
		cinematique_front.transform.Translate (-0.4f*Time.deltaTime, 0, 0);
		cinematique_middle.transform.Translate (-0.3f*Time.deltaTime, 0, 0);
		cinematique_back.transform.Translate (-0.2f*Time.deltaTime, 0, 0);
		cinematique_sky.transform.Translate (-0.1f*Time.deltaTime, 0, 0);
	}

}
