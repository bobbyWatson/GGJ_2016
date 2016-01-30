using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public partial class Player : MonoBehaviour {

	private Rigidbody2D mRigidBody;
	public int speed;

	void AwakeLouis(){
		mRigidBody = GetComponent<Rigidbody2D> ();
	}

	void StartLouis(){

	}

	void FixedUpdateLouis(){
		Vector2 force = new Vector2( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;
		mRigidBody.AddForce(force);
	}

	void UpdateLouis(){

	}

	void Move(){

	}

	void SetIndexSprites(){

	}
}
