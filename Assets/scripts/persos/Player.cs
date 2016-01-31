using UnityEngine;
using System.Collections;

public partial class Player : MonoBehaviour {

	BoxCollider2D mCollider;
	Transform mTransform;
	public bool camFollowActive = false;
	public bool inSecondPhase = false;

	void Awake(){
		mTransform = GetComponent<Transform> ();
		mCollider = mTransform.GetComponentInChildren<BoxCollider2D> ();
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

	void LateUpdate(){
		LateUpdateLouis ();
	}
}
