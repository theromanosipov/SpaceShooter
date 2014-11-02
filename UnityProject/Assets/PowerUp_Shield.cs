using UnityEngine;
using System.Collections;

public class PowerUp_Shield : MonoBehaviour {
	public GameObject shield;
	private GameObject tShield;
	void OnTriggerEnter( Collider other) {
		if (other.tag == "Player") {
			tShield=Instantiate(shield, other.transform.position, Quaternion.identity) as GameObject;
			tShield.transform.parent = other.transform;
			Destroy( gameObject);
		}
	}
}
