using UnityEngine;
using System.Collections;
/// <summary>
/// Meele Turret daroma žala;
/// </summary>
public class MeeleTurret : MonoBehaviour {
	
	public float ContactDamage;
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag != "Enemy") {
			return;
		}
		other.gameObject.BroadcastMessage("GetDamage", ContactDamage);
	}
}
