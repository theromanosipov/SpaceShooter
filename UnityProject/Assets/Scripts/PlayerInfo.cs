using UnityEngine;
using System.Collections;

/// <summary>
/// Saugo informaciją apie konkretų žaidėją: kontrolerio numerį, surinktu taškus.
/// Leidžia gauti žaidėjo nuspaustus mygtukus ir gauti bei modifikuoti taškus.
/// </summary>
public class PlayerInfo : MonoBehaviour {

	public int controllerNumber;
	private long score = 0;
	
	public float GetAxisH() {
		return Input.GetAxis( "Horizontal" + controllerNumber);
	}
	
	public float GetAxisV() {
		return Input.GetAxis( "Vertical" + controllerNumber);
	}
	
	public bool GetButtonDock() {
		return Input.GetButton("Dock" + controllerNumber);
	}
	
	public bool GetButtonPowerup() {
		return Input.GetButton("Fire" + controllerNumber);
	}
	
	public bool GetButtonMelee() {
		return Input.GetButton("Melee" + controllerNumber);
	}
	
	public long GetScore() {
		return score;
	}

	public float HitPoints;
	public int ContactDamage;
	
	public void AddScore( long newScore) {
		score += newScore;
	}
	void GetDamage(int Damage)
	{
		HitPoints -= Damage;
		if (HitPoints <= 0) {
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter (Collider other) {
		if (other.tag != "Enemy") {
			return;
		}
		other.gameObject.BroadcastMessage("GetDamage", ContactDamage);
	}
}
