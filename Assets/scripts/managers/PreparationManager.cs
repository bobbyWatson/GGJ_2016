using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PreparationManager : MonoBehaviour {
	//singleton
	private static PreparationManager _instance;
	public static PreparationManager Instance{
		get{
			if(_instance == null){
				_instance = FindObjectOfType<PreparationManager>();
			}
			return _instance;
		}
	}
	//publics
	public const float TOTAL_TIME = 45;

	public SpriteRenderer blackScreen;
	public Sprite leftBotPnj;
	public Sprite leftTopPnj;
	public Sprite rightTopPnj;
	public Sprite rightBotPnj;
	public GameObject PhrasePrefab;
	public Sprite bulleSprite;
	public GameObject pnjPrefab;
	public Group[] groups;
	public GroupeParam[] groupParams;
	public Transform spotRoot;
	public int chosenLD;
	public GroupSpot[] spots;
	//privates

	//methods
	public IEnumerator Start(){
		Init ();
		//fade in
		blackScreen.gameObject.SetActive (true);
		float timer = 0;
		Color c = new Color (0, 0, 0, 0);
		while (timer < 1) {
			c.a = Mathf.Lerp (1, 0, timer / 1f);
			blackScreen.color = c;
			yield return null;
			timer += Time.deltaTime;
		}
		blackScreen.gameObject.SetActive (false);
		//game timer;
		timer = 0;
		while (timer < TOTAL_TIME) {
			yield return null;
			timer += Time.deltaTime;
		}
		//fade out
		blackScreen.gameObject.SetActive (true);
		timer = 0;
		c = new Color (0, 0, 0, 0);
		while (timer < 1) {
			c.a = Mathf.Lerp (0, 1, timer / 1f);
			blackScreen.color = c;
			yield return null;
			timer += Time.deltaTime;
		}
		SceneManager.LoadScene ("Main");
	}

	public void Init(){
		//Define LD
		int previousLD = -1;
		chosenLD = -1;
		if (PlayerPrefs.HasKey ("PREVIOUS_LD")) {
			previousLD = PlayerPrefs.GetInt("PREVIOUS_LD");
		}
		do{
			chosenLD = Random.Range(0,3);
		}while(chosenLD == previousLD);
		PlayerPrefs.SetInt ("PREVIOUS_LD", chosenLD);
		//Get Spots
		spots = new GroupSpot[spotRoot.childCount + 1];
		foreach (Transform t in spotRoot) {
			GroupSpot gs = t.gameObject.GetComponent<GroupSpot> ();
			spots [gs.ID] = gs;
		}
		//initGroups
		for (int i = 0; i < groups.Length; i++) {
			groups [i].Init (groupParams [i]);
		}
	}

}
