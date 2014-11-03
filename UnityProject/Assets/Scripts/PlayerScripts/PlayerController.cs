using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
  public float xMin, xMax, zMin, zMax;
}

public class PlayerController : GenericPlayerController {
  public float speed;
  public Boundary boundery;
	public GameObject meele;
	private GameObject tMeele;
  
  void Start(){
		tMeele=Instantiate(meele, transform.position, Quaternion.Euler (0f,120f,0)) as GameObject;
		tMeele.transform.parent = transform;
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
