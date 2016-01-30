using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class cinematique : MonoBehaviour {

	public GameObject[] cinematique_front;
	public GameObject[] cinematique_back;
	public GameObject[] cinematique_decor_back;
	public GameObject[] cinematique_bloc;
	private int i = 0;

	// Use this for initialization
	void Start () {
		Debug.Log (i);
		StartCoroutine(SleepSecs(3));
		Instantiate(cinematique_bloc[0], new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
	}

	// Update is called once per frame
	void Update () {
		cinematique_front[i].transform.Translate (0.4f*Time.deltaTime, 0, 0);
		cinematique_back[i].transform.Translate (-0.2f*Time.deltaTime, 0, 0);
		cinematique_decor_back[i].transform.Translate (-0.1f*Time.deltaTime, 0, 0);
	}


	IEnumerator SleepSecs (float secs) {
		yield return new WaitForSeconds(secs);
		SceneManager.LoadScene("Main");
	}
}
