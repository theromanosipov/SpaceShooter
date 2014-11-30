using UnityEngine;
using System.Collections;

public class DestroyByCollision : MonoBehaviour {
    public GameObject explosion;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Boundary")
            return;
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
