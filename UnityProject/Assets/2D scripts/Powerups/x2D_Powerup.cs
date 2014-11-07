using UnityEngine;
using System.Collections;

public class x2D_Powerup : MonoBehaviour {

	private bool activated=false;
	// Laivas, kuris bus spawinamas, kai žaidėjas paims powerup'ą
	public GameObject newShip;
	void OnTriggerEnter2D( Collider2D other) {
		if (other.tag == "Player"&&activated==false) {
			activated=true;
			// Sukuria nauja lavą newShip
			GameObject ship = Instantiate(newShip, other.gameObject.transform.position, Quaternion.identity) as GameObject;
			
			// Perduoda PlayerInfo iš other į naujai sukurtą laivą
			ship.GetComponent<PlayerInfoContainer>().SetPlayerInfo(other.gameObject.GetComponent<PlayerInfoContainer>().GetPlayerInfo());
			
			Dock otherDock = other.gameObject.GetComponentsInChildren<Dock>()[0];
			GameObject turret = otherDock.GetTurret();
			
			if ( turret != null) {
				ship.GetComponentsInChildren<Dock>()[0].DockTurret( turret);
			}
			
			Destroy( other.gameObject);
			Destroy( gameObject);
		}
	}
}
