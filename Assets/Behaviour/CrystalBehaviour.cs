using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBehaviour : Collectable {
	public int crystalType;
	protected override void OnRabitHit(HeroRabbit rabit){
		if (crystalType == 1)
			LevelController.current.crystal1 = true;
		else if (crystalType == 2)
			LevelController.current.crystal2 = true;
		else if (crystalType == 3)
			LevelController.current.crystal3 = true;
		this.CollectedHide ();
	}
}
