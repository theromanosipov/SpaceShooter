using UnityEngine;
using System.Collections;

public class E_Shot_Mover : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		rigidbody.velocity = -speed*transform.up;

	}

}
