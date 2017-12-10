using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFollow : MonoBehaviour {

	public HeroRabbit hero;

	// Update is called once per frame
	void Update () {

		Transform h_tr = hero.transform;
		Transform this_tr = this.transform;

		Vector3 h_pos = h_tr.position;
		Vector3 this_pos = this_tr.position;

		this_pos.x = h_pos.x;
		this_pos.y = h_pos.y;

		this_tr.position = this_pos;
	}
}
