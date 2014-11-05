using UnityEngine;
using System.Collections;

public class SimpleShot: MonoBehaviour {
	public float speed;
	public int damage;
	// Use this for initialization
	void Start () {
		rigidbody.velocity = speed*transform.up;

	}

	void OnTriggerEnter (Collider other) {
		if (other.tag != "Enemy") {
			return;
		}
		other.gameObject.SendMessage("GetDamage", damage);
		Destroy (gameObject);
	}

}
