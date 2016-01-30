using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public partial class Player : MonoBehaviour {

	private SpriteRenderer spriteRenderer;
	private Camera cam;
	private Rigidbody2D mRigidBody;
	public int speed;

	void AwakeLouis(){
		cam = Camera.main;
		mRigidBody = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void StartLouis(){

	}

	void FixedUpdateLouis(){
		Move ();
		SetIndexSprites ();
	}

	void LateUpdateLouis(){
		cam.transform.position = new Vector3 (mTransform.position.x, mTransform.position.y, cam.transform.position.z);
	}

	void UpdateLouis(){

	}

	void Move(){
		Vector2 force = new Vector2( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;
		mRigidBody.AddForce(force);
	}

	void SetIndexSprites(){
		Vector2 scale = new Vector2 (mTransform.localScale.x * spriteRenderer.sprite.texture.width, mTransform.localScale.y * spriteRenderer.sprite.texture.height);
		Vector2 pos = new Vector2 (mTransform.position.x, mTransform.position.y);
		Rect myRect = new Rect (pos,scale);
		SpriteManager.Instance.SetSpritesIndex (myRect);
	}
}
