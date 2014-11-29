using UnityEngine;
using System.Collections;

public class PlayerTurretController : MonoBehaviour {

	private int playerNumber;
	public float speed;

	void Update () {	
		//transform.Rotate(Vector3.right * Time.deltaTime * Input.GetAxis( "Horizontal" + playerNumber) * speed);
		Debug.Log( playerNumber);
	}
	
	public void SetPlayerNumber( int newNumber) {
		playerNumber = newNumber;
	}
}
	

