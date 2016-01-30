using UnityEngine;
using System.Collections;

public class TestPlayerMove : MonoBehaviour {

    public float Speed;

    Transform mTransform;
    Rigidbody2D mRigidbody;

	// Use this for initialization
	void Awake () {
        mTransform = GetComponent<Transform>();
        mRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 force = new Vector2( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Speed * Time.deltaTime;
        mRigidbody.AddForce(force);
	}
}
