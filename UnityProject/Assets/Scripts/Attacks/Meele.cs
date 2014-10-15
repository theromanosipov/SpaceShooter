using UnityEngine;
using System.Collections;

public class Meele : MonoBehaviour {
	public int meeleDamage;
	private PlayerInfo player;

	// Use this for initialization
	void Start () {
		player = gameObject.transform.parent.GetComponent<PlayerInfo> ();
	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.tag != "Enemy") {
			return;
				}
		if (player.GetButtonMelee ()) {
			other.gameObject.BroadcastMessage("GetDamage", meeleDamage);
				}
	}
}
