using UnityEngine;
using System.Collections;

/// <summary>
/// Dock skriptas skirtas dokui prie, kurio jungsis laivai.
/// </summary>
public class Dock : MonoBehaviour {

	private Dockable dockable;
	private PlayerInfo player;
	
	private bool isDockEmpty = true;
    //Pauzė kad vos tik prisijungęs laivas ta pačia akimirka neatsijungtu
	private float dockPause;
	
	void Update() {
		if( !isDockEmpty && dockPause < Time.time && player.GetButtonDock()) {


			Debug.Log( "Dock kinda works");
		}
	}

	void OnTriggerStay( Collider other) {
		if( other.tag == "Dockable" && isDockEmpty && Time.time > dockPause) {
			dockable = other.gameObject.GetComponent <Dockable>();
			player = other.gameObject.GetComponent <PlayerInfoContainer>().playerInfo;
			if( dockable == null)
				Debug.Log( "Cannot find Dockable script when docking");
			else if( player == null)
				Debug.Log( "Cannot find PlayerInfo when docking");
            //Čia visi veiksmai, kurie atliekami, kai laivas gali ir nori prisijungti
			else if ( player.GetButtonDock()) {
				isDockEmpty = false;
                dockPause = Time.time + 0.5f;
				Destroy( other.gameObject);

                GameObject turret = Instantiate( dockable.turret) as GameObject;
                turret.GetComponent<PlayerInfoContainer>().playerInfo = player;

				Debug.Log( "You got docked boy");
				}
			else
				Debug.Log( "Ship does not want to dock");
		}
	}
}

