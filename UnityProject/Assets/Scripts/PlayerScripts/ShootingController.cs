using UnityEngine;
using System.Collections;

public class ShootingController : GenericPlayerController
{
	public GameObject shot;
	public Transform[] shotSpawns;
	public float fireRate;
	private float nextFire;
	
	public override void Update() {
		base.Update();
		if (player.GetButtonPowerup() && Time.time > nextFire) {
			nextFire = Time.time + 1 / fireRate;
			foreach(Transform shotSpawn in shotSpawns)
			{ 
			Instantiate( shot, shotSpawn.position, shotSpawn.rotation);
			}
		}
	}
}

