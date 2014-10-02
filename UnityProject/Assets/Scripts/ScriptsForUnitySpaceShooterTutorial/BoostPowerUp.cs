using UnityEngine;
using System.Collections;

public class BoostPowerUp : GenericPowerUp {

  public float shipSpeedMultiplyer;
  public float fireRateMultiplier;
  public float duration;
  
  void OnTriggerEnter( Collider other) {
	if (other.tag == "Player") {
	  ApplyPowerUp();
	  collider.enabled = false;
	  renderer.enabled = false;
	}
  }
	
  protected override void ApplyPowerUp() {
	StartCoroutine( playerController.TimedSpeedMultiply( shipSpeedMultiplyer, fireRateMultiplier, duration, gameObject));
  }
}
