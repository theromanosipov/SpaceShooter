using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

    // Laivas, kuris bus spawinamas, kai žaidėjas paims powerup'ą
    public GameObject newShip;

    void OnTriggerEnter( Collider other) {
        if (other.tag == "Player") {
            // Sukuria nauja lavą newShip
            GameObject ship = Instantiate(newShip, other.gameObject.transform.position, Quaternion.identity) as GameObject;

			// Perduoda PlayerInfo iš other į naujai sukurtą laivą
			ship.GetComponent<PlayerInfoContainer>().SetPlayerInfo(other.gameObject.GetComponent<PlayerInfoContainer>().GetPlayerInfo());

			Dock otherDock = other.gameObject.GetComponents<Dock>()[0];
			GameObject turret = otherDock.GetTurret();

			if ( turret != null) {
				//ship.GetComponents<Dock>()[0].DockTurret( turret);
			}

            Destroy( other.gameObject);
			Destroy( gameObject);
        }
    }
}
