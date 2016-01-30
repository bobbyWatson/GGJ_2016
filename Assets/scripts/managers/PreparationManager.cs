using UnityEngine;
using System.Collections;

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
	public void Start(){
		Init ();
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
