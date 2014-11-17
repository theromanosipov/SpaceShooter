using UnityEngine;
using System.Collections;

public class ShootingController : GenericPlayerController
{
	public GameObject shot;
	public Transform[] shotSpawns;
	public float fireRate;
	public float scatter;
	public float scatterK;
	public float shotCount = 0;
	public float maxShots = 1;
	private float nextFire;
	
	public override void Update() {
		base.Update();
		if (Time.time > nextFire&&shotCount<maxShots) {
			shotCount++;
			nextFire = Time.time + 1 / fireRate;
		}
		scatter = Mathf.Pow(shotCount,0.5f)*scatterK;
		if (player.GetButtonPowerup() && shotCount > 0) {
			foreach(Transform shotSpawn in shotSpawns)
			{ 
				GameObject bullet = Instantiate( shot, shotSpawn.position, Quaternion.Euler (shotSpawn.rotation.eulerAngles.x,shotSpawn.rotation.eulerAngles.y+Random.Range (-scatter,scatter),shotSpawn.rotation.eulerAngles.z)) as GameObject;
				bullet.BroadcastMessage("AssignPlayer", player);
			}
			shotCount--;
		}
	}
}

