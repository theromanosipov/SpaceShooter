using UnityEngine;
using System.Collections;

public class Maze_Mover : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = -transform.up * speed;
	}

	void FixedUpdate () {
		if (transform.childCount == 0) {
			Destroy (gameObject);
		}
	}
}
