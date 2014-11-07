using UnityEngine;
using System.Collections;

public class x2D_Meele : GenericPlayerController {

	public int meeleDamage;
	public float swingTime = 0.2f;
	public float cooldown = 0.4f;	
	private float pressStart = 0;
	
	public override void Update(){
		base.Update();
		if (Time.time - pressStart > swingTime) {
			gameObject.renderer.enabled = false;
		}
		if (player.GetButtonMelee () && Time.time - pressStart > cooldown + swingTime) {
			gameObject.renderer.enabled = true;
			pressStart = Time.time;
		}
		
		float swangle = (Time.time - pressStart) / swingTime * 120;
		transform.parent.rotation = Quaternion.Euler(0,0,-Mathf.Clamp(60f + swangle, 60f, 120f));
		
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag != "Enemy" || Time.time - pressStart > swingTime) {
			return;
		}
		Debug.Log ("Meele hit");
		other.gameObject.SendMessage("GetDamage", meeleDamage);
	}
}
