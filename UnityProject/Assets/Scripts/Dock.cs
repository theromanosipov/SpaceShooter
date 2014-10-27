using UnityEngine;
using System.Collections;

/// <summary>
/// Dock skriptas skirtas dokui prie, kurio jungsis laivai.
/// </summary>
public class Dock : MonoBehaviour {

	public float minTurretRotation, maxTurretRotation;

	private PlayerInfoContainer player;
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
			ship.GetComponent<PlayerInfoContainer>().SetPlayerInfo( player.GetPlayerInfo());

            isDockEmpty = true;
			Debug.Log( "Dock kinda works");
		}
	}

	void OnTriggerStay( Collider other) {
		if( other.tag == "Player" && isDockEmpty && Time.time > dockPause) {
			Dockable dockable = other.gameObject.GetComponent <Dockable>();
			player = other.gameObject.GetComponent <PlayerInfoContainer>();

            //Čia visi veiksmai, kurie atliekami, kai laivas gali ir nori prisijungti
			if ( player.GetButtonDock()) {
				isDockEmpty = false;
                dockPause = Time.time + 0.5f;
				Destroy( other.gameObject);
                turret = Instantiate(dockable.otherForm, transform.position, Quaternion.identity) as GameObject;
                turret.GetComponent<PlayerInfoContainer>().SetPlayerInfo( player.GetPlayerInfo());
				turret.transform.parent = transform;

				Debug.Log( "You got docked boy");
			}
			else
				Debug.Log( "Ship does not want to dock");
		}
	}
}/

