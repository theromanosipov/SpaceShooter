using UnityEngine;
using System.Collections;

/// <summary>
/// Dock skriptas skirtas dokui prie, kurio jungsis laivai.
/// </summary>
public class Dock : MonoBehaviour {

	private Dockable dockable;
	private PlayerInfo player;
	
	private bool isDockEmpty = true;
	private float dockPause;
	
	void Update() {
		if( !isDockEmpty && player.GetButtonDock()) {
			Debug.Log( "Dock kinda works");
		}
	}

	void OnTriggerStay( Collider other) {
		if( other.tag == "Dockable" && isDockEmpty && Time.time > dockPause) {
			dockable = other.gameObject.GetComponent <Dockable>();
			//player = other.gameObject.GetComponent <PlayerInfo>();
			if( dockable == null)
				Debug.Log( "Cannot find Dockable script when docking");
			else if( player == null)
				Debug.Log( "Cannot find PlayerInfo script when docking");
			else if ( player.GetButtonDock()) {
				isDockEmpty = false;
				Destroy( other.gameObject);
				Debug.Log( "You got docked boy");
				}
			else
				Debug.Log( "Ship does not want to dock");
		}
	}
}

