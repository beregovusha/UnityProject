using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLineTriger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {
		//Намагаємося отримати компонент кролика
		HeroRabbit rabit = collider.GetComponent<HeroRabbit> ();
		//Впасти міг не тільки кролик
		if(rabit != null) {
			//Повідомляємо рівень, про смерть кролика
			LevelController.current.OnRabbitDeath (rabit);
		}
	}
}
