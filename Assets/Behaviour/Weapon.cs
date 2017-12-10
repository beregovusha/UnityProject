using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collectable {

	public static GameObject proto;

	public float speed = 1.0f;
	public float lifetime = 3.0f;

	private bool isActive = false;

	void Start()
	{
		if (proto == null)
			proto = GameObject.Find ("Carrot");
	}

	void FixedUpdate(){
		if (!isActive)
			return;
		
		Vector3 newPos = transform.position;
		newPos.x += speedCoef * Time.deltaTime;
		transform.position = newPos;
	}

	float speedCoef;

	public static Weapon newWeapon(float xDirection)
	{
		Weapon newO = GameObject.Instantiate (proto).GetComponent<Weapon>();
		if (xDirection < 0) {
			newO.speedCoef = -1 * Weapon.proto.GetComponent<Weapon>().speed;
			newO.GetComponent<SpriteRenderer> ().flipX = true;
		} else {
			newO.speedCoef = Weapon.proto.GetComponent<Weapon>().speed;
		}
		return newO;
	}

	public void Go(){
		isActive = true;
		StartCoroutine (DestroyerWait());
	}

	IEnumerator DestroyerWait(){
		yield return new WaitForSeconds (lifetime);
		Destroy (this.gameObject);
	}
	protected override void OnRabitHit(HeroRabbit rabit){
		LevelController.current.OnRabbitDeath(rabit, false);
		Destroy (this.gameObject);
	}
}
