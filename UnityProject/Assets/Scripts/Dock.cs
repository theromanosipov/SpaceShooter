using UnityEngine;
using System.Collections;

public class Dock : MonoBehaviour {

	private Dockable dockable;
	private GameObject dockedTurret;
	private bool isDockEmpty = true;
	private int dockedPlayerNumber;
	private float dockPause;
	
	void Update() {
		if( !isDockEmpty && Input.GetButton( "Dock" + dockedPlayerNumber) && Time.time > dockPause) {
			dockable.transform.position = dockedTurret.transform.position;
			dockable.gameObject.SetActive( true);
			Destroy( dockedTurret);
			dockPause = Time.time + 0.1f;
			isDockEmpty = true;
		}
	}

	void OnTriggerStay( Collider other) {
		if( other.tag == "Dockable" && isDockEmpty && Time.time > dockPause) {
			GameObject dockableObject = other.gameObject;
			if( dockableObject != null)
				dockable = dockableObject.GetComponent <Dockable>();
			if( dockable == null)
				Debug.Log( "Cannot find Dockable script");
			else {
				GameObject turret = dockable.SuggestEntry();
				if( turret != null) {
					dockable.gameObject.SetActive( false);
					dockedTurret = Instantiate( turret, transform.position, Quaternion.identity) as GameObject;
					dockedTurret.transform.parent = transform;
					dockedPlayerNumber = dockable.GetPlayerNumber();
					isDockEmpty = false;
					dockPause = Time.time + 0.1f;
					Debug.Log( "Ship wants to dock");
				}
				else
					Debug.Log( "Ship does not want to dock");
			}
		}
	}
}
