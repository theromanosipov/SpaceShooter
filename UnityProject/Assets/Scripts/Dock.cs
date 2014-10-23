using UnityEngine;
using System.Collections;

/// <summary>
/// Dock skriptas skirtas dokui prie, kurio jungsis laivai.
/// </summary>
public class Dock : MonoBehaviour {

	private PlayerInfo player;
    private GameObject turret;
	
	private bool isDockEmpty = true;
    //Pauzė kad vos tik prisijungęs laivas ta pačia akimirka neatsijungtu
	private float dockPause;
	
	void Update() {
        //Turretas sunaikinamas ir spawninamas laivas
		if( !isDockEmpty && dockPause < Time.time && player.GetButtonDock()) {
            dockPause = Time.time + 0.5f;  
            Destroy( turret);
            Dockable dockable = turret.GetComponent<Dockable>();

            GameObject ship = Instantiate(dockable.otherForm, transform.position, Quaternion.identity) as GameObject;
            ship.GetComponent<PlayerInfoContainer>().playerInfo = player;

            isDockEmpty = true;
			Debug.Log( "Dock kinda works");
		}
	}

	void OnTriggerStay( Collider other) {
		if( other.tag == "Dockable" && isDockEmpty && Time.time > dockPause) {
			Dockable dockable = other.gameObject.GetComponent <Dockable>();
			player = other.gameObject.GetComponent <PlayerInfoContainer>().playerInfo;

            //Čia visi veiksmai, kurie atliekami, kai laivas gali ir nori prisijungti
			if ( player.GetButtonDock()) {
				isDockEmpty = false;
                dockPause = Time.time + 0.5f;
				Destroy( other.gameObject);
                turret = Instantiate(dockable.otherForm, transform.position, Quaternion.identity) as GameObject;
                turret.GetComponent<PlayerInfoContainer>().playerInfo = player;

				Debug.Log( "You got docked boy");
			}
			else
				Debug.Log( "Ship does not want to dock");
		}
	}
}

