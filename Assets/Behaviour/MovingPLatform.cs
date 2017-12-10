using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPLatform : MonoBehaviour {

	public Vector3 pointB;
	public bool active = false;
	public float speed = 1.0f;
	public float timeout = 1.0f;

	Vector3 pointA;
	Vector3 tempTarget;
	float tempTimer = -1;

	// Use this for initialization
	void Start () {
		pointA = transform.position;
		if (!active)
			pointB = pointA;
		tempTarget = pointA;
	}

	bool isArrived(Vector3 pos, Vector3 target)
	{
		pos.z = 0;
		target.z = 0;
		return Vector3.Distance (pos, target)<0.02f;

	}

	// Update is called once per frame
	void Update () {
		if (active) {
			tempTimer -= Time.deltaTime;
			//next we will change direction and renew timer
			if (isArrived (this.transform.position, tempTarget)) {
				if (tempTarget == pointA)
					tempTarget = pointB;
				else
					tempTarget = pointA;
				tempTimer = timeout;
			}

			if (tempTimer < 0) {
				Vector3 me = transform.position;
				Vector3 target = tempTarget;
				target.z = me.z;
				transform.position = Vector3.MoveTowards (me, target, speed);
			}
			//if ()
		}
	}
}
