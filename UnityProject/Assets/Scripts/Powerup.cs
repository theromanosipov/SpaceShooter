using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

    // Laivas, kuris bus spawinamas, kai žaidėjas paims powerup'ą
    public GameObject newShip;

    void OnTriggerEnter( Collider other) {
        if (other.tag == "Player") {
            // Sukuria nauja lavą newShip
            GameObject ship = Instantiate(newShip, other.gameObject.transform.position, Quaternion.identity) as GameObject;

            // Perduoda other doke esantį turretą naujai sukurtam ship
			GameObject turret = other.gameObject.GetComponent<Dock>().GetTurret();
			if ( turret != null)
				ship.GetComponent<Dock>().DockTurret( turret);

            // Perduoda PlayerInfo iš other į naujai sukurtą laivą
            ship.GetComponent<PlayerInfoContainer>().SetPlayerInfo(other.gameObject.GetComponent<PlayerInfoContainer>().GetPlayerInfo());
            Destroy( other.gameObject);
			Destroy( gameObject);
        }
    }
}
