using UnityEngine;
using System.Collections;

public class Dockable : MonoBehaviour {

	public GameObject turretForm;
	private PlayerController playerController;
	
	void Start() {
		playerController = gameObject.GetComponent<PlayerController>();
	}
	
	public GameObject SuggestEntry() {
		if( Input.GetButton("Dock" + playerController.playerNumber)) {
			return turretForm;
		}
		else {
			return null;
		}
	}
}
