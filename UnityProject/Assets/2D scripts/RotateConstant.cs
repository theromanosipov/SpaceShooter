using UnityEngine;
using System.Collections;

public class RotateConstant : MonoBehaviour {

    public float rate;

	void FixedUpdate () {
        rigidbody2D.rotation += rate;
	}
}
