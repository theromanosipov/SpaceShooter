using UnityEngine;
using System.Collections;
/// <summary>
/// Homing missile mover'is
/// Viliaus
/// </summary>
public class HomingMissile : MonoBehaviour
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
	private PlayerInfoContainer shooter;
	private Vector3 direction;
		// Use this for initialization
		void Start ()
		{
			timer = false;
			rigidbody.velocity = speed1*transform.up;
			activator = Time.time + delay; 
			
		}
		void FixedUpdate ()
		{
			if (Time.time >= activator && timer == false) {
			//Debug.Log ("aaa");
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
			if (minDist <= range) {        Vector3 directionOfTravel = enemy0.transform.position - currentPos;
				directionOfTravel.Normalize();
				direction=rigidbody.velocity;
				direction.Normalize();
				rigidbody.velocity = (inertia*direction+directionOfTravel)/(inertia+1)*speed2;
				//Quaternion _lookRotation = Quaternion.LookRotation(rigidbody.velocity);
				//rigidbody.rotation = _lookRotation;	
				transform.rotation= Quaternion.Euler(90f,(180f/3.14f)*Mathf.Atan(rigidbody.velocity.x/rigidbody.velocity.z),0);
				
			} else{//rigidbody.rotation =  Quaternion.identity;	
				direction=rigidbody.velocity;
				direction.Normalize();
				rigidbody.velocity = direction * speed2;
			}
				}
		}
		void OnTriggerEnter (Collider other) {
		if (other.tag != "Enemy") {
			return;
		}
		other.gameObject.SendMessage("GetDamage", damage);
		Destroy (gameObject);
	}

	public void AssignPlayer(PlayerInfoContainer player){
		shooter = player;
	}
}

