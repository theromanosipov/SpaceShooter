using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
  public float xMin, xMax, zMin, zMax;
}

public class PlayerController : GenericPlayerController {
  public float speed;
  public Boundary boundery;
  public int playerNumber;
  
  public GameObject shot;
  public Transform shotSpawn;
  public float fireRate;
  private float nextFire;
  
  public override void Update() {
  	base.Update();
	if (player.GetButtonPowerup() && Time.time > nextFire) {
	  nextFire = Time.time + 1 / fireRate;
	  Instantiate( shot, shotSpawn.position, shotSpawn.rotation);
    }
  }
  
  void FixedUpdate() {


	rigidbody.velocity = new Vector3( player.GetAxisH() * speed, 0.0f, player.GetAxisV() * speed);
    
    rigidbody.position = new Vector3(
	  Mathf.Clamp( rigidbody.position.x, boundery.xMin, boundery.xMax),
      0.0f,
	  Mathf.Clamp( rigidbody.position.z, boundery.zMin, boundery.zMax)
    );  
  }
}
