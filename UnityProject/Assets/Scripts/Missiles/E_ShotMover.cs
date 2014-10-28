using UnityEngine;
using System.Collections;
/// <summary>
/// Priešų šūvių mover'is
/// Turi metodą, kuris iškviečia GetDamage susidūrus su žaidėju 
/// (Gal būt yra galimybė šitą iškelti į kitą script'ą.)
/// Viliaus
/// </summary>
public class E_ShotMover : MonoBehaviour {

	public float speed; //Kokiu greičiu skrenda šūviai
	public int damage;  //Kiek žalos daro
	// Use this for initialization
	void Start () {
		rigidbody.velocity = -speed*transform.up;

	}

	void OnTriggerEnter (Collider other) {
		if (other.tag != "Player") {
			return;
		}
		other.gameObject.BroadcastMessage("GetDamage", damage);
		Destroy (gameObject);
	}

}
