using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsLabelWatcher : MonoBehaviour {

	private UILabel label;
	private int lastTimeWas =-1;

	void Start () {
		label = this.GetComponent<UILabel> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (LevelController.current.coins != lastTimeWas) {
			lastTimeWas = LevelController.current.coins;
			label.text = lastTimeWas.ToString ();
			while (label.text.Length < 4)
				label.text = "0" + label.text;
		}
	}
}
