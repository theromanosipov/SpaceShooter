using UnityEngine;
using System.Collections;

public class Dock : MonoBehaviour {

	private Dockable dockable;
	private GameObject dockedTurret;
	private GameObject dockedShip;

	void OnTriggerStay( Collider other) {
		if( other.tag == "Dockable" && dockedShip == null) {
			GameObject dockableObject = other.gameObject;
			if( dockableObject != null)
				dockable = dockableObject.GetComponent <Dockable>();
			if( dockable == null)
				Debug.Log( "Cannot find Dockable script");
			else {
				GameObject turret = dockable.SuggestEntry();
				if( turret != null) {
					dockedShip = dockableObject;
					dockedShip.SetActive( false);
					dockedTurret = Instantiate( turret, transform.position, Quaternion.identity) as GameObject;
					dockedTurret.transform.parent = transform;
					Debug.Log( "Ship wants to dock");
				}
				else
					Debug.Log( "Ship does not want to dock");
			}
		}
	}
}
