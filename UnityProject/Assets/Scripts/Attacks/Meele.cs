﻿using UnityEngine;
using System.Collections;

public class Meele : MonoBehaviour {
	public int meeleDamage;
	public float swingTime = 0.2f;
	public float cooldown = 0.4f;
	private PlayerInfo player;
	private bool right = true;
	private float pressStart = 0;

	// Use this for initialization
	void Start () {
		player = gameObject.transform.parent.GetComponent<PlayerInfo> ();
	}

	void Update(){
		if (player.GetButtonMelee () && Time.time - pressStart > cooldown + swingTime) {
			right = !right;
			pressStart = Time.time;
		}

		float swangle = (Time.time - pressStart) / swingTime * 120;
		if(right){

			transform.rotation = Quaternion.Euler(0,Mathf.Clamp(60f + swangle, 60f, 120f),0);
				}
		else{
			transform.rotation = Quaternion.Euler(0,Mathf.Clamp(120f - swangle, 60f, 120f),0);
		}
		
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag != "Enemy") {
			return;
				}
		other.gameObject.BroadcastMessage("GetDamage", meeleDamage);
	}
}
