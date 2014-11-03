using UnityEngine;
using System.Collections;
/// <summary>
/// Skydo power up'as. Uždeda Shield prefab'ą. Stack'inasi
/// </summary>
public class PowerUp_Shield : MonoBehaviour {
	public GameObject shield;	//Shield'o prefabas
	private GameObject tShield; //Naudojamas įvaikinti skydą laivui.
	void OnTriggerEnter( Collider other) {
		if (other.tag == "Player") {
			tShield=Instantiate(shield, other.transform.position, Quaternion.identity) as GameObject;
			tShield.transform.parent = other.transform;
			Destroy( gameObject);
		}
	}
}
