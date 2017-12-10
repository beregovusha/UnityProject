using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBehaviour : Collectable {
	protected override void OnRabitHit(HeroRabbit rabit){
		if (!rabit.isBig())
			rabit.resizeMakeBig ();
		this.CollectedHide ();
	}
}
