using UnityEngine;
using System.Collections;

public class PlayerInfoContainer : MonoBehaviour {

	private PlayerInfo playerInfo;

	void Update() {
		if (playerInfo == null)
			Debug.Log ("PlayerInfoContainer negauna PlayerInfo");
	}

	public void SetPlayerInfo( PlayerInfo newPLayer) {
		playerInfo = newPLayer;
	}

	public PlayerInfo GetPlayerInfo() {
		return playerInfo;
	}

	public float GetAxisH() {
		return Input.GetAxis( "Horizontal" + playerInfo.controllerNumber);
	}
	
	public float GetAxisV() {
		return Input.GetAxis( "Vertical" + playerInfo.controllerNumber);
	}
	
	public bool GetButtonDock() {
		return Input.GetButton("Dock" + playerInfo.controllerNumber);
	}
	
	public bool GetButtonPowerup() {
		return Input.GetButton("Fire" + playerInfo.controllerNumber);
	}
	
	public bool GetButtonMelee() {
		return Input.GetButton("Melee" + playerInfo.controllerNumber);
	}
	
	public long GetScore() {
		return playerInfo.score;
	}
	
	public void AddScore( long newScore) {
		playerInfo.score += newScore;
	}

	public void GetDamage( int hitPoints) {
		playerInfo.hitPoints -= hitPoints;
	}
}
