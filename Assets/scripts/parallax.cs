using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class parallax : MonoBehaviour {

	public GameObject cinematique_front;
	public GameObject cinematique_sol;
	public GameObject cinematique_back;
	public GameObject cinematique_decor_back;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		cinematique_front.transform.Translate (-0.4f*Time.deltaTime, 0, 0);
		cinematique_sol.transform.Translate (-0.3f*Time.deltaTime, 0, 0);
		cinematique_back.transform.Translate (-0.2f*Time.deltaTime, 0, 0);
		cinematique_decor_back.transform.Translate (-0.1f*Time.deltaTime, 0, 0);
	}

}
