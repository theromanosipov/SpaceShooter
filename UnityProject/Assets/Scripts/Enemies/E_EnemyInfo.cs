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
	
	// Update is called once per frame
	void GetDamage(int Damage)
	{
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
