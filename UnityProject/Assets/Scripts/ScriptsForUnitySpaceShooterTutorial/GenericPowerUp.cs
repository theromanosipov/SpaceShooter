using UnityEngine;
using System.Collections;

public abstract class GenericPowerUp : MonoBehaviour {

  protected GameController gameController;
  protected PlayerController playerController;

  void Start () {
	GameObject gameControllerObject = GameObject.FindWithTag( "GameController");
	if( gameControllerObject != null)
	  gameController = gameControllerObject.GetComponent <GameController>();
	if( gameController == null)
	  Debug.Log( "Cannot find GameController script");
	GameObject playerControllerObject = GameObject.FindWithTag( "Player");
	if( playerControllerObject != null)
	  playerController = playerControllerObject.GetComponent <PlayerController>();
	if( playerController == null)
	  Debug.Log( "Cannot find PlayerController script");
  }

  void OnTriggerEnter( Collider other) {
	if (other.tag == "Player") {
	  ApplyPowerUp();
	  Destroy( gameObject);
	}
  }
  
  abstract protected void ApplyPowerUp();
}
