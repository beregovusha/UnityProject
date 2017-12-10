using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBehaviour : Collectable {
	void Start(){
		LevelController.current.fruitsAtAll += 1;
	}
	protected override void OnRabitHit(HeroRabbit rabit){
		LevelController.current.fruits += 1;
		this.CollectedHide ();
	}
}
