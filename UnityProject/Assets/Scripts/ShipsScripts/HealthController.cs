using UnityEngine;
using System.Collections;

public class HealthController : GenericPlayerController {
	public float invincibilityDuration = 2f;
	public float invincibilityCooldown = 0f;
	public Color invincibilityColor = new Color (150, 50, 50);

	private float invincibleUntil = 0f;

	
	public override void Update(){
		base.Update();
		if (Time.time >= invincibleUntil + invincibilityCooldown) gameObject.renderer.material.color = new Color(0.0f,0.0f,1f);
		else if (Time.time >= invincibleUntil) gameObject.renderer.material.color = new Color(0.5f,0.5f,1f);
	}

	public void GetDamage(int damage){
		if (Time.time < invincibleUntil)
				return;
		else if (Time.time > invincibleUntil + invincibilityCooldown){
				invincibleUntil = Time.time + invincibilityDuration;
				gameObject.renderer.material.color = invincibilityColor;
		}
		player.AddHitpoints (-damage);
	}
}
