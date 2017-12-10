using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : Collectable {
	protected override void OnRabitHit(HeroRabbit rabit){
		LevelController.current.coins += 1;
		this.CollectedHide ();
	}

}
