using UnityEngine;
using System.Collections;

/// <summary>
/// PlayerInfoContainer saugo PlayerInfo ir suteikia interfeisą gauti ir keisti informaciją apie laivą
/// </summary>
public class PlayerInfoContainer : MonoBehaviour {
	private PlayerInfo playerInfo;

    // Debuginimui
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

	public int GetHitPoints(){
		return playerInfo.hitPoints;
	}
	public void AddHitpoints( int hitPoints) {
		playerInfo.hitPoints += hitPoints;
		//Debug.Log ("HitPoints " + playerInfo.hitPoints);
		if (playerInfo.hitPoints <= 0) {
			DestroyShip();
		}
	}

    public void SetDockPause( float newDockPause) {
        playerInfo.dockPause = Time.time + newDockPause;
    }

    public bool IsDockPause() {
        if (playerInfo.dockPause > Time.time)
            return true;
        else
            return false;
    }

	void DestroyShip(){
		Destroy (gameObject);
	}
}
