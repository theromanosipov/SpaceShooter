using UnityEngine;
using System.Collections;
/// <summary>
/// EnemyInfo klasė, kurioje yra saugoma kiek gyvybių turi priešas ir kiek žalos padaro žaidėjui kontakto metu.
/// Taip pat tuti GetDamage metodą.
/// Laivas prisilietęs prie žaidėjo yra sunaikinamas.
/// Turi metodą DestroyShip -> vėliau jame explosion'o inicijavimą reiks įdėt.
/// Viliaus
/// </summary>
public class x2D_EnemyInfo : MonoBehaviour {
	
	// Use this for initialization
	public int HitPoints;		//Laivo gyvybės.
	public int ContactDamage;	//Kiek žalos daro žaidėjui kontakto metu
	public float colorResetTime=0.3f;
	public bool isInvincible=false;
	public bool isDestroyableByCollision = true;
	public Color enemyColor = new Color (1f, 0.7f, 0.7f);
	private float resetTime;
	
	void Update()
	{
		if (Time.time >= resetTime) {gameObject.renderer.material.color = enemyColor;}
	}
	// Update is called once per frame
	void GetDamage(int Damage)
	{
		
		resetTime = Time.time + colorResetTime;
		if (isInvincible) {
						gameObject.renderer.material.color = new Color (0.5f, 0.5f, 0.5f);
						return;
				}
		gameObject.renderer.material.color = new Color(1f,0,0);
		HitPoints -= Damage;
		if (HitPoints <= 0) {
			DestroyShip ();
		}
	}
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag != "Player") {
			return;
		}
		//Debug.Log ("Player hit by mover");
		other.gameObject.SendMessage("GetDamage", ContactDamage);
		if (!isDestroyableByCollision) {
						return;
		}
		DestroyShip ();
	}
	void DestroyShip(){
		Destroy (gameObject);
	}
}
