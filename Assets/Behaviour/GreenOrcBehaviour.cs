using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenOrcBehaviour : MonoBehaviour {

	enum Target{
		Rabbit, PointA, PointB, undef
	}

	public Vector3 pointB;
	public float speed=1.0f;
	public float runspeed = 2.0f;
	public bool AlternativePositionMarker = false;
	public Vector3 alternative_MoveDistVector;
	Vector3 pointA;

	private Animator myA;
	private SpriteRenderer mySR;
	private bool goingToA = false;
	private bool needFlip = false;
	void Start () {
		pointA = this.transform.position;
		if (AlternativePositionMarker)
			pointB = pointA + alternative_MoveDistVector;
		myA = this.GetComponent<Animator> ();
		mySR = this.GetComponent<SpriteRenderer> ();
	}
	// 0-idle, 1-walk, 2-run, 3-attack1, 4-attack2, 5-die
	void SetAction(int recomended_animation){
		myA.SetInteger ("action", recomended_animation);
	}
	int specialAction=0;
	// Update is called once per frame
	void FixedUpdate () {
		if (specialAction != 0) {
			SetAction (specialAction);
			//if (specialAction == 4)
			//	specialAction = 0;
			return;
		}
		SetAction (0);
		Target targ = nextTarget ();

		Vector3 old_pos = transform.position;

		if (targ == Target.PointA) {
			this.transform.position = Vector3.MoveTowards (old_pos, LevelController.zProjection (pointA, transform.position.z), speed*Time.deltaTime);
			SetAction (1); 
		} else if (targ == Target.PointB) {
			this.transform.position = Vector3.MoveTowards (old_pos, LevelController.zProjection (pointB, transform.position.z), speed*Time.deltaTime);
			SetAction (1);
		} else if (targ == Target.Rabbit) {
			Vector3 rabbi = HeroRabbit.lastRabbit.transform.position;
			rabbi.y = old_pos.y; 
			rabbi.z = old_pos.z;
			transform.position = Vector3.MoveTowards (old_pos, rabbi, runspeed*Time.deltaTime);
			SetAction (2);
		}
		old_pos -= transform.position;
		if (old_pos.x > 0)
			mySR.flipX = false;
		else
			mySR.flipX = true;
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Player") {
			if (Mathf.Abs (Mathf.Atan (
				    (transform.position.y - HeroRabbit.lastRabbit.transform.position.y) /
				    (transform.position.x - HeroRabbit.lastRabbit.transform.position.x)
			    )) < 1) {
				StartCoroutine(attack2 ());
				LevelController.current.OnRabbitDeath (HeroRabbit.lastRabbit, false);
			}else
				die ();
		}
	}

	Target nextTarget(){
		if (HeroRabbit.lastRabbit.transform.position.x > Mathf.Min (pointA.x, pointB.x))
		if (HeroRabbit.lastRabbit.transform.position.x < Mathf.Max (pointA.x, pointB.x))
			return Target.Rabbit;

		if (goingToA) {
			if (isNear (transform.position, pointA))
				goingToA = false;
			return Target.PointA;
		} else {
			if (isNear (transform.position, pointB))
				goingToA = true;
			return Target.PointB;
		}
	}

	bool isNear(Vector3 pos, Vector3 target)
	{
		pos.z = 0;
		target.z = 0;
		return Vector3.Distance (pos, target)<0.1f;
	}

	void die(){
		Destroy (this.GetComponent<BoxCollider2D>());
		Destroy (this.GetComponent<Rigidbody2D> ());
		StartCoroutine (die_sub());
	}
	IEnumerator die_sub(){
		specialAction = 5;
		yield return new WaitForSeconds (3);
		Destroy (this.gameObject);
	}
	IEnumerator attack2(){
		specialAction = 4;
		yield return new WaitForSeconds (1);
		specialAction = 0;
	}
}
