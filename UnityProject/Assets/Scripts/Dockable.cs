using UnityEngine;
using System.Collections;

public class Dockable : MonoBehaviour {

	public PlayerTurretController turretForm;
	private PlayerController playerController;
	
	void Start() {
		playerController = gameObject.GetComponent<PlayerController>();
		turretForm.SetPlayerNumber( playerController.playerNumber);
	}
	
	public GameObject SuggestEntry() {
		if( Input.GetButton("Dock" + playerController.playerNumber)) {
			return null;
		}
		else {
			return null;
		}
	}
	
	public int GetPlayerNumber() {
		return playerController.playerNumber;
	}
}
