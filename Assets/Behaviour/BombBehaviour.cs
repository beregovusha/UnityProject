using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : Collectable {
	protected override void OnRabitHit(HeroRabbit rabit){
		if (rabit.isBig ())
			rabit.resizeMakeSmall ();
		else {
			LevelController.current.OnRabbitDeath (rabit, false);
		}	
		this.CollectedHide ();
	}
}
