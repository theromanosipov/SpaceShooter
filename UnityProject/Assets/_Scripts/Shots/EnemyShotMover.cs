using UnityEngine;
using System.Collections;
/// <summary>
/// Priešų šūvių mover'is
/// Turi metodą, kuris iškviečia GetDamage susidūrus su žaidėju 
/// (Gal būt yra galimybė šitą iškelti į kitą script'ą.)
/// Viliaus
/// </summary>
public class EnemyShotMover : MonoBehaviour {
	
	public float speed; //Kokiu greičiu skrenda šūviai
	public int damage;  //Kiek žalos daro
	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = -speed*transform.up;
		
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag != "Player"&&other.tag !="Shield") {
			return;
		}
		other.gameObject.SendMessage("GetDamage", damage);
		Destroy (gameObject);
	}
	
}
