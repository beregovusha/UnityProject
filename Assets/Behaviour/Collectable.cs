using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable:MonoBehaviour{
	protected virtual void OnRabitHit(HeroRabbit rabit){}

	protected bool hideAnimation=false;

	void OnTriggerEnter2D(Collider2D collider){
		if(!this.hideAnimation){
			HeroRabbit rabit=collider.GetComponent<HeroRabbit>();
			if(rabit!=null){
				this.OnRabitHit(rabit);
			}
		}
	}

	public void CollectedHide(){
		this.hideAnimation = true;
		Destroy(this.gameObject);
	}
}