using UnityEngine;
using System.Collections;

public class PlayerInfoContainer : MonoBehaviour {

	private PlayerInfo playerInfo;
	private float colorResetTime;
	private float resetTime;

	void Start()
	{
		colorResetTime = 0.3f;
	}

	void Update() {
		if (Time.time >= resetTime) {gameObject.renderer.material.color = new Color(0.5f,0.5f,1f);}
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
		gameObject.renderer.material.color = new Color(1f,0,0f);
		resetTime = Time.time + colorResetTime;
		playerInfo.hitPoints -= hitPoints;
		Debug.Log ("HitPoints " + playerInfo.hitPoints);
		if (playerInfo.hitPoints <= 0) {
			Destroy(gameObject);
				}
	}
}
