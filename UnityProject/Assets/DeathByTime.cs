using UnityEngine;
using System.Collections;

public class DeathByTime : MonoBehaviour {

    private float deathTime;
    public float lifetime;

	void Start () {
        deathTime = Time.time + lifetime;
	}
	
	
	void Update () {
        if (Time.time > deathTime)
            Destroy(gameObject);
	}
}
