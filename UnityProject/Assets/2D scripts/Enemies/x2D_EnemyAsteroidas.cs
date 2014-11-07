using UnityEngine;
using System.Collections;
/// <summary>
/// Asteroidų mover'is
/// Viliaus
/// </summary>
public class x2D_EnemyAsteroidas : MonoBehaviour {
	
	public float[] speed = new float[2];	//greičio min ir max vertės
	public float hspeed;					//Kintamasis apsprendžiantis nuokrypį nuo horizontalės.
	void Start () {
		rigidbody2D.velocity = -transform.up * Random.Range (speed[0], speed[1])+
									new Vector3 (Random.Range (-hspeed, hspeed), 0,0);
	}
}
