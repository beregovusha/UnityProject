using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRabbit : MonoBehaviour {

	public float speed = 3.0f;
	public float jumpSpeed = 2f;
	public float jumpMaxTime = 2f;

	public static HeroRabbit lastRabbit ;

	private float jumpTime = 0;

	private Rigidbody2D myRB = null;
	private SpriteRenderer mySR = null;
	private Animator myA = null;
	private BoxCollider2D myBC = null;
	private Transform savedParent;
	// Use this for initialization
	void Start () {
		//init variables
		myRB = this.GetComponent<Rigidbody2D>();
		mySR = this.GetComponent<SpriteRenderer> ();
		myA = this.GetComponent<Animator> ();
		myBC = this.GetComponent<BoxCollider2D> ();
		savedParent = transform.parent;
		//freeze rotation
		myRB.freezeRotation = true;
		//remember start position
		Vector3 myVec = this.transform.position;
		LevelController.current.SetStartPosition (myVec);

	}
		
	void Awake(){
		lastRabbit = this;
	}
	//private int action=0;

	//public float coefVectorUp =0.3f;
	//public float coefVectorDown =0.1f;

	private bool isGrounded (){
		return LevelController.isOn (this, "Ground");
	}

	private RaycastHit2D tempMovingPlatformHit;
	private bool isOnMovingPlatform(){
		tempMovingPlatformHit = LevelController.getPlatform(this, "MovingPlatform");
		if (tempMovingPlatformHit)
			return true;
		else
			return false;
	}
	private void jump()
	{
		this.jumpTime += Time.deltaTime;
		if (this.jumpTime < this.jumpMaxTime) 
		{
			Vector2 vel = myRB.velocity;
			vel.y = jumpSpeed * (1.0f - jumpTime / jumpMaxTime);
			myRB.velocity = vel;
		}
	}


	void FixedUpdate () {
		
		float runvalue = Input.GetAxis ("Horizontal");
		int action = 0;

		if (isDead) {
			myA.SetInteger ("action", 4);
			return;
		}

		bool isOnMoveingPlatformVar = isOnMovingPlatform();
		bool isGroundedVar = isGrounded ();
		//or
		if (isOnMoveingPlatformVar) {
			isGroundedVar = true;
			LevelController.SetParent (transform, tempMovingPlatformHit.transform);
		} else {
			LevelController.SetParent (transform, savedParent);
		}
		if (Input.GetButton ("Jump")) {
			if (isGroundedVar)
				jumpTime = 0.0f;
			if (this.jumpTime < this.jumpMaxTime)
				jump ();
		} else {
			jumpTime += jumpMaxTime;
		}
		if (!isGroundedVar)
			action = 2;
		
		if (Mathf.Abs (runvalue) > 0) {
			Vector2 vel = myRB.velocity;
			vel.x = runvalue * speed;
			myRB.velocity = vel;

			if (action==0)
				action = 1;
		}

		myA.SetInteger ("action", action);

		if(runvalue < 0) {
			mySR.flipX = true;
		} else if(runvalue > 0) {
			mySR.flipX = false;
		}
	}

	bool isBigv =false;
	public bool isBig(){
		return isBigv;
	}
	public bool isDead =false;
	public void resizeMakeBig(){
		transform.localScale *= 2;
		isBigv = true;
	}
	public void resizeMakeSmall(){
		transform.localScale /= 2;
		isBigv = false;
	}
}
