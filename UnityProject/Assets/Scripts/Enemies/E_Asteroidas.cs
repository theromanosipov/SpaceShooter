using UnityEngine;
using System.Collections;

public class E_Asteroidas : MonoBehaviour {

	public float HitPoints;
	public float[] speed;
	public float tumble;
	public float angle;
	void Start () {
		rigidbody.velocity = transform.forward * Random.Range (speed[0], speed[1])+new Vector3 (Random.Range (-angle, angle), 0, 0);
		rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
	}
	public void GetDamage(int Damage)
	{
		HitPoints -= Damage;
		if (HitPoints <= 0) {
			Destroy(gameObject);
				}
	}
}
