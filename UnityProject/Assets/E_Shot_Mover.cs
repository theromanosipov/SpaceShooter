using UnityEngine;
using System.Collections;

public class E_Shot_Mover : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		rigidbody.velocity = new Vector3(0.0f, 0.0f, -speed);

	}

}
