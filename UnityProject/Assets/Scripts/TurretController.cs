using UnityEngine;
using System.Collections;

public class TurretController : GenericPlayerController {

	public float speed;
	public float distance;
	private float angle;
	private bool isRotationClamped;	
	private float minAngle;
	private float maxAngle;
	void Start() {
		angle = 0;
		isRotationClamped = false;
	}
	void FixedUpdate () {
		angle += 3.14f/180f*speed * player.GetAxisH ();
		if (isRotationClamped) {
			Mathf.Clamp (angle,minAngle,maxAngle);
				}
		transform.position = transform.parent.position+distance*new Vector3 (Mathf.Sin (angle), 0.0f, Mathf.Cos (angle));
		transform.rotation = Quaternion.Euler (0.0f, angle, 0.0f);
	}

	public void RestrictRotation(float minAngle, float maxAngle) {
		isRotationClamped = true;
		this.minAngle = minAngle;
		this.maxAngle = maxAngle;
	}

}
