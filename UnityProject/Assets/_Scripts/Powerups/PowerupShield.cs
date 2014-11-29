using UnityEngine;
using System.Collections;
/// <summary>
/// Skydo power up'as. Uždeda Shield prefab'ą. Stack'inasi
/// </summary>
public class PowerupShield : MonoBehaviour {
	public GameObject shield;	//Shield'o prefabas
	private GameObject tShield; //Naudojamas įvaikinti skydą laivui.
	void OnTriggerEnter2D( Collider2D other) {
		if (other.tag == "Player") {
			tShield=Instantiate(shield, other.transform.position, Quaternion.identity) as GameObject;
			tShield.transform.parent = other.transform;
			Destroy( gameObject);
		}
	}
}
