using UnityEngine;
using System.Collections;

public class E_EnemyShipNr1 : MonoBehaviour {
	public float range;
	public float speed1;
	public float speed2;
	public float Damage;

	void Start () {
		rigidbody.velocity = -transform.forward * speed1;
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
			rigidbody.velocity = directionOfTravel * speed2;

		} else{		rigidbody.velocity = -transform.forward * speed1;
				}
	}

}
