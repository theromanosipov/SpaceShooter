using UnityEngine;
using System.Collections;

public class MeeleTurret : MonoBehaviour {

	public float ContactDamage;

	void OnTriggerEnter (Collider other) {
		if (other.tag != "Enemy") {
			return;
		}
		Debug.Log ("Player hit by mover");
		other.gameObject.BroadcastMessage("GetDamage", ContactDamage);
	}
}
