using UnityEngine;
using System.Collections;
/// <summary>
/// EnemyInfo klasė, kurioje yra saugoma kiek gyvybių turi priešas ir kiek žalos padaro žaidėjui kontakto metu.
/// Taip pat tuti GetDamage metodą.
/// Laivas prisilietęs prie žaidėjo yra sunaikinamas.
/// Turi metodą DestroyShip -> vėliau jame explosion'o inicijavimą reiks įdėt.
/// Viliaus
/// </summary>
public class E_EnemyInfo : MonoBehaviour {

	// Use this for initialization
	public int HitPoints;		//Laivo gyvybės.
	public int ContactDamage;	//Kiek žalos daro žaidėjui kontakto metu
	public float colorResetTime;
	private float resetTime;

	void Start()
	{
		colorResetTime = 0.3f;
	}

	void Update()
	{
		if (Time.time >= resetTime) {gameObject.renderer.material.color = new Color(1f,0.7f,0.7f);}
	}
	// Update is called once per frame
	void GetDamage(int Damage)
	{
		gameObject.renderer.material.color = new Color(1f,0,0);
		resetTime = Time.time + colorResetTime;
		HitPoints -= Damage;
		if (HitPoints <= 0) {
			DestroyShip ();
		}
	}
	void OnTriggerEnter (Collider other) {
		if (other.tag != "Player") {
			return;
		}
		Debug.Log ("Player hit by mover");
		other.gameObject.BroadcastMessage("GetDamage", ContactDamage);
		DestroyShip ();
	}
	void DestroyShip(){
		Destroy (gameObject);
	}
}
