using UnityEngine;
using System.Collections;

public class BouncingWall : MonoBehaviour {
	private Vector2 normal;
	void Start(){
		float tmp = transform.rotation.eulerAngles.z / 180 * Mathf.PI;
		normal = new Vector2(Mathf.Sin(tmp), - Mathf.Cos(tmp));
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag != "Shot") {
			return;
		}
		other.rigidbody2D.velocity = other.rigidbody2D.velocity - 2 * Vector2.Dot(other.rigidbody2D.velocity, normal) * normal;
		other.rigidbody2D.rotation = transform.rotation.eulerAngles.z * 2 - other.rigidbody2D.rotation;
	}
}
