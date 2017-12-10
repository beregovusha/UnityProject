using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarWatcher : MonoBehaviour {

	private GameObject h1, h2, h3;
	private int wasLastTime;
	void Start () {
		//UI2DSprite[] arr = this.gameObject.GetComponentsInChildren<UI2DSprite>();
		//this.gameObject.SetActive(false);
		//throw new UnityException (arr.Length.ToString());
		h1 = getChildGameObject(this.gameObject, "Life1");
		h2 = getChildGameObject(this.gameObject, "Life2");
		h3 = getChildGameObject(this.gameObject, "Life3");
		wasLastTime = -1;
	}
	private static GameObject getChildGameObject(GameObject parent, string childName){
		Transform[] ts = parent.GetComponentsInChildren<Transform>();
		foreach (Transform t in ts)
			if (t.name == childName)
				return t.gameObject;
		return null;
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (LevelController.current.health != wasLastTime) {
			wasLastTime = LevelController.current.health;
			if (wasLastTime == 3) {
				h1.SetActive (true);
				h2.SetActive (true);
				h3.SetActive (true);
			} else if (wasLastTime == 2) {
				h1.SetActive (true);
				h2.SetActive (true);
				h3.SetActive (false);
			} else if (wasLastTime == 1) {
				h1.SetActive (true);
				h2.SetActive (false);
				h3.SetActive (false);
			} else {
				h1.SetActive (false);
				h2.SetActive (false);
				h3.SetActive (false);
			}
		}
	}
}
