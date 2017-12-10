using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour {

	public bool isLocked = true;
	public string leadsTo = "LevelChoose";

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag != "Player")
			return;
		if (isLocked)
			return;
		LevelLoader ll = new LevelLoader ();
		ll.SceneName = leadsTo;
		ll.load ();
	}
}
