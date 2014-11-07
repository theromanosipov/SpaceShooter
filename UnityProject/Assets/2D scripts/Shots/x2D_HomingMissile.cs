using UnityEngine;
using System.Collections;
/// <summary>
/// Homing missile mover'is
/// Viliaus
/// </summary>
public class x2D_HomingMissile : MonoBehaviour
{
	public float speed1; 		//Pradinis missile greitis (iki tol, kol praeina delay laikas)
	public float speed2; 		//Greitis po delay laiko
	public float range;			//Kokiu atstumu "pastebi" taikinius
	public float damage;		//Kiek žalos daro
	public float delay;			//Po kiek laiko pradeda ieškoti taikinių ir po kiek laiko iš speed1 pereinam į speed2
	public float inertia;		//Parametras, kuris nurodo ant kiek inertiškas šūvis (kaip greitai gali keisti kryptį
	//Kuo mažesnis šis parametras, tuo greičiau gali keisti
	private float activator;	
	private bool timer;
	private Vector3 direction;
	// Use this for initialization
	void Start ()
	{
		timer = false;
		rigidbody2D.velocity = speed1*transform.up;
		activator = Time.time + delay; 
		
	}
	void FixedUpdate ()
	{
		if (Time.time >= activator && timer == false) {
			timer=true;
		}
		if (timer == true) {
			var players=GameObject.FindGameObjectsWithTag("Enemy");
			GameObject enemy0 = null;
			float minDist = Mathf.Infinity;
			Vector3 currentPos = transform.position;
			foreach (GameObject p in players)
			{
				float dist = Vector3.Distance(p.transform.position, currentPos);
				if (dist < minDist)
				{
					enemy0 = p;
					minDist = dist;
				}
			}
			if (minDist <= range) {        
				Vector3 directionOfTravel = enemy0.transform.position - currentPos;
				directionOfTravel.Normalize();
				direction=rigidbody2D.velocity;
				direction.Normalize();
				rigidbody2D.velocity = (inertia*direction+directionOfTravel)/(inertia+1)*speed2;
				transform.rotation= Quaternion.Euler(0,0,90+(180/3.14159f)*Mathf.Atan(rigidbody2D.velocity.y/rigidbody2D.velocity.x));
				
			} else{
				direction=rigidbody2D.velocity;
				direction.Normalize();
				rigidbody2D.velocity = direction * speed2;
			}
		}
	}
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag != "Enemy") {
			return;
		}
		other.gameObject.SendMessage("GetDamage", damage);
		Destroy (gameObject);
	}
}

