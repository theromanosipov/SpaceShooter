using UnityEngine;
using System.Collections;

public class x2D_SimpleShot: MonoBehaviour {
	public float speed;
	public int damage;
	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = speed*transform.up;
		
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag != "Enemy") {
			return;
		}
		other.gameObject.SendMessage("GetDamage", damage);
		Destroy (gameObject);
	}
	
}