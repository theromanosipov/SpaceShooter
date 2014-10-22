using UnityEngine;
using System.Collections;

public class E_HitPoints : MonoBehaviour {

	// Use this for initialization
	public int HitPoints;
	public int ContactDamage;
	
	// Update is called once per frame
	void GetDamage(int Damage)
	{
		HitPoints -= Damage;
		if (HitPoints <= 0) {
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter (Collider other) {
		if (other.tag != "Player") {
			return;
		}
		Debug.Log ("Player hit by mover");
		other.gameObject.BroadcastMessage("GetDamage", ContactDamage);
	}
}
