using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
	public static LevelController current;

	public int coins = 0;
	public int health = 3;
	public int fruits = 0;
	public int fruitsAtAll = 0;
	public bool crystal1 = false, crystal2 = false, crystal3 = false;



	public float deathWaitTime = 3.0f;
	private Vector3 startPos;

	void Awake() {
		current = this;
	}

	public void OnRabbitDeath(HeroRabbit rb)
	{
		OnRabbitDeath (rb, true);
	}

	public void OnRabbitDeath(HeroRabbit rb, bool instantly){
		if (!rb.isDead)
			health -= 1;
		if (instantly) {
			Transform rbt = rb.transform;
			rbt.position = this.startPos;
		} else {
			if (rb.isBig()) {
				rb.resizeMakeSmall ();
				health += 1;
				return;
			}
			StartCoroutine (DeathAnimation(rb));
		}
		if (health <= 0) {
			LevelLoader ll = new LevelLoader ();
			ll.SceneName = "LevelChoose";
			ll.load ();
		}
	}

	IEnumerator DeathAnimation(HeroRabbit rb){
		//rb.GetComponents<Animator> () [0].speed = deadBodyWait;
		rb.isDead = true;
		yield return new WaitForSeconds (deathWaitTime);
		rb.isDead = false;
		Transform rbt = rb.transform;
		rbt.position = this.startPos;
	}

	public void SetStartPosition (Vector3 sp){
		startPos.x = sp.x;
		startPos.y = sp.y;
	}

	public static bool isOn(MonoBehaviour someone, string layer){
		Vector3 from = someone.transform.position + Vector3.up * 0.5f;
		Vector3 to = someone.transform.position + Vector3.up * 0.0f;

		Debug.DrawLine (from, to);

		int layer_id = 1 << LayerMask.NameToLayer (layer);
		//Перевіряємо чи проходить лінія через Collider з шаром Ground
		RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);
		if(hit) {
			return true;
		}
		return false;
	}
	public static RaycastHit2D getPlatform(MonoBehaviour someone, string layer){
		Vector3 from = someone.transform.position + Vector3.up * 0.3f;
		Vector3 to = someone.transform.position + Vector3.up * 0.1f;

		Debug.DrawLine (from, to);

		int layer_id = 1 << LayerMask.NameToLayer (layer);
		//Перевіряємо чи проходить лінія через Collider з шаром Ground
		return Physics2D.Linecast(from, to, layer_id);

	}
	public static void SetParent(Transform obj, Transform new_parent){
		if (obj.transform.parent != new_parent) {
			Vector3 pos = obj.transform.position;
			obj.transform.parent = new_parent;
			obj.position = pos;
		}
	}
	public static Vector3 zProjection(Vector3 input, float z){
		input.z = z;
		return input;
	}
	public static GameObject getChildGameObject(GameObject parent, string childName){
		Transform[] ts = parent.GetComponentsInChildren<Transform>();
		foreach (Transform t in ts)
			if (t.name == childName)
				return t.gameObject;
		return null;
	}
}
