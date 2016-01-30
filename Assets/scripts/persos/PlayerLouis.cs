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
		Move ();
		SetIndexSprites ();
	}

	void UpdateLouis(){

	}

	void Move(){
		Vector2 force = new Vector2( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;
		mRigidBody.AddForce(force);
	}

	void SetIndexSprites(){
		Vector2 scale = new Vector2 (mTransform.localScale.x, mTransform.localScale.y);
		Vector2 pos = new Vector2 (mTransform.position.x, mTransform.position.y);
		Rect myRect = new Rect (pos,scale);
		SpriteManager.Instance.SetSpritesIndex (myRect);
	}
}
