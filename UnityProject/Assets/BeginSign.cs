using UnityEngine;
using System.Collections;

public class BeginSign : MonoBehaviour {

    private GameObject gameMaster;

    void Start() {
        gameMaster = GameObject.FindGameObjectsWithTag("GameMaster")[0];
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Shot") {
            gameMaster.audio.Play();
            Destroy(gameObject);
        }
    }
}
