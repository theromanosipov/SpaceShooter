using UnityEngine;
using System.Collections;

public class WallCollision : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Shot" || other.tag == "Enemy") {
            Destroy(other.gameObject);
        }
        else if (other.tag == "Player") {
            other.gameObject.SendMessage("DestroyShip");
        }
    }
}
