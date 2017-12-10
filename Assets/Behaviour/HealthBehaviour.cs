using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : Collectable {

	protected override void OnRabitHit(HeroRabbit rabit){
		if (LevelController.current.health < 3)
			LevelController.current.health += 1;
		this.CollectedHide ();
	}

}
