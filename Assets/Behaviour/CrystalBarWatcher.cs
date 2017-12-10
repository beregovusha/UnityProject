using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBarWatcher : MonoBehaviour {

	GameObject c1, c2, c3;
	// Use this for initialization
	void Start () {
		c1 = LevelController.getChildGameObject (this.gameObject, "Crystal1");
		c2 = LevelController.getChildGameObject (this.gameObject, "Crystal2");
		c3 = LevelController.getChildGameObject (this.gameObject, "Crystal3");
	}
	
	// Update is called once per frame
	void Update () {
		c1.SetActive (LevelController.current.crystal1);
		c2.SetActive (LevelController.current.crystal2);
		c3.SetActive (LevelController.current.crystal3);
	}
}
