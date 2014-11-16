using UnityEngine;
using System.Collections;

public class Maze_Cube : MonoBehaviour {
	public int damage = 10000;
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Shot")
						Destroy (other.gameObject);
		if (other.tag == "Enemy" || other.tag == "Player")
						other.SendMessage ("GetDamage", damage);

	}
}
