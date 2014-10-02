using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
  public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
  public float speed;
  public Boundary boundery;
  public int playerNumber;
  
  public GameObject shot;
  public Transform shotSpawn;
  public float fireRate;
  private float nextFire;
  
  void Update() {
	if (Input.GetButton("Fire" + playerNumber) && Time.time > nextFire) {
	  nextFire = Time.time + 1 / fireRate;
	  Instantiate( shot, shotSpawn.position, shotSpawn.rotation);
    }
  }
  
  void FixedUpdate() {
	float moveHorizontal = Input.GetAxis( "Horizontal" + playerNumber) * speed;
	float moveVertical = Input.GetAxis( "Vertical" + playerNumber) * speed;

    Vector3 movement = new Vector3( moveHorizontal, 0.0f, moveVertical);
    rigidbody.velocity = movement;
    
    rigidbody.position = new Vector3(
	  Mathf.Clamp( rigidbody.position.x, boundery.xMin, boundery.xMax),
      0.0f,
	  Mathf.Clamp( rigidbody.position.z, boundery.zMin, boundery.zMax)
    );  
  }
}
