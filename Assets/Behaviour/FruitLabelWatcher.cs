using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitLabelWatcher : MonoBehaviour {

	private UILabel label;
	private int wasLastTime = -1;
	// Use this for initialization
	void Start () {
		label = this.GetComponent<UILabel> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (wasLastTime != LevelController.current.fruits) {
			wasLastTime = LevelController.current.fruits;
			label.text = "" + wasLastTime + "/" + LevelController.current.fruitsAtAll;
		}
	}
}
