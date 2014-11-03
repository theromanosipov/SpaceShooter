using UnityEngine;
using System.Collections;
/// <summary>
/// Meele Turret daroma žala;
/// </summary>
public class MeeleTurret : MonoBehaviour {

	public float ContactDamage;

	void OnTriggerEnter (Collider other) {
		if (other.tag != "Enemy") {
			return;
		}
		other.gameObject.BroadcastMessage("GetDamage", ContactDamage);
	}
}
