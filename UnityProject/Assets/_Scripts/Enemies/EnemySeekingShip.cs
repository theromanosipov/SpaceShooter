using UnityEngine;
using System.Collections;
/// <summary>
/// EnemyShip Nr1. mover'is -> Sekiojantis laivas
/// Viliaus
/// </summary>
public class EnemySeekingShip : MonoBehaviour {
	public float range;	 //kokiu atstumu pastebi žaidėją.
	public float speed1; //kokiu greičiu juda, nepastebėjęs žaidėjo.
	public float speed2; //kokiu greičiu juda, kai pastebi žaidėją.
	
	void Start () {
		transform.rotation = Quaternion.Euler (0, 0, 180);
	}
	
	void Update () {		
		var players=GameObject.FindGameObjectsWithTag("Player");
		
		GameObject player_0 = null;
		float minDist = Mathf.Infinity;
		Vector3 currentPos = transform.position;
		foreach (GameObject p in players)
		{
			float dist = Vector3.Distance(p.transform.position, currentPos);
			if (dist < minDist)
			{
				player_0 = p;
				minDist = dist;
			}
		}
		if (minDist <= range) {        Vector3 directionOfTravel = player_0.transform.position - currentPos;
			directionOfTravel.Normalize();
			rigidbody2D.velocity = directionOfTravel * speed2;
			transform.rotation= Quaternion.Euler(0,0,-90+(180/3.14159f)*Mathf.Atan(rigidbody2D.velocity.y/rigidbody2D.velocity.x));
			
		} else{	
			rigidbody2D.velocity = transform.up * speed1;
		}
	}
}
