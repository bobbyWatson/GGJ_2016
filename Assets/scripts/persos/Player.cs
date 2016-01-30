using UnityEngine;
using System.Collections;

public partial class Player : MonoBehaviour {


	Transform mTransform;

	void Awake(){
		mTransform = GetComponent<Transform> ();
		AwakeLouis ();
		AwakeManu ();
	}

	void Start(){
		StartLouis ();
		StartManu ();
	}

	void Update(){
		UpdateLouis ();
		UpdateManu ();
	}

	void FixedUpdate(){
		FixedUpdateLouis ();
		FixedUpdateManu ();
	}

}
