using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public partial class Player : MonoBehaviour {

	private Animator animator;
	private SpriteRenderer spriteRenderer;
	private Camera cam;
	private Rigidbody2D mRigidBody;
	public int speed;

	public bool canMove = true;
	public float canMoveTime = 0f;

	void AwakeLouis(){
		cam = Camera.main;
		mRigidBody = GetComponent<Rigidbody2D> ();
		spriteRenderer = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator> ();
	}

	void StartLouis(){

	}

	void FixedUpdateLouis(){
		Move ();
		SetIndexSprites ();
	}

	void LateUpdateLouis(){
		if (camFollowActive) {
			cam.transform.position = new Vector3 (Mathf.Clamp(mTransform.position.x,-1713, 1673),
				Mathf.Clamp(mTransform.position.y, -704, 712),
				cam.transform.position.z);
		}
	}

	void UpdateLouis(){
		animator.SetFloat ("speed", mRigidBody.velocity.magnitude);
		updateCanMove ();
	}

	void Move(){
		if (canMove) {
			Vector2 force = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical")) * speed;
			animator.SetBool ("moving", force.magnitude > 0);
			mRigidBody.AddForce (force);
			if (force.x < 0) {
				mTransform.localScale = new Vector3 (-1, 1, 1);
			} else if (force.x > 0) {
				mTransform.localScale = new Vector3 (1, 1, 1);
			}
		}
	}

	void setCantMoveForSeconds(float seconds) {
		canMove = false;
		canMoveTime = Time.time + seconds;
	}

	void updateCanMove() {
		if (!canMove && Time.time >= canMoveTime) {
			canMove = true;
		}
	}

	void SetIndexSprites(){
		Vector2 scale = new Vector2 (mTransform.localScale.x * spriteRenderer.sprite.bounds.size.x, mTransform.localScale.y * spriteRenderer.sprite.bounds.size.y);
		Vector2 pos = new Vector2 (mTransform.position.x, mTransform.position.y);
		Rect myRect = new Rect (pos,scale);
		SpriteManager.Instance.SetSpritesIndex (myRect);
	}
}
