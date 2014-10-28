using UnityEngine;
using System.Collections;
/// <summary>
/// Asteroidų mover'is
/// Viliaus
/// </summary>
public class E_Asteroidas : MonoBehaviour {

	public float[] speed = new float[2];	//greičio min ir max vertės
	public float tumble;					//Kokiu greičiu sukasi asteroidas (praktiškai tik vizualus efektas)
	public float hspeed;					//Kintamasis apsprendžiantis nuokrypį nuo horizontalės.
	void Start () {
		rigidbody.velocity = -transform.forward * Random.Range (speed[0], speed[1])+new Vector3 (Random.Range (-hspeed, hspeed), 0, 0);
		rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
