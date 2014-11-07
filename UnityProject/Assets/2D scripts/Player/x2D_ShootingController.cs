using UnityEngine;
using System.Collections;

public class x2D_ShootingController : GenericPlayerController
{
	public GameObject shot;
	public Transform[] shotSpawns;
	public float fireRate;
	private float scatter;
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
				Instantiate( shot, shotSpawn.position, 
				            Quaternion.Euler 
				            (shotSpawn.rotation.eulerAngles.x,
				 shotSpawn.rotation.eulerAngles.y,
				 shotSpawn.rotation.eulerAngles.z+Random.Range (-scatter,scatter))
				            );
				
			}
			shotCount--;
		}
	}
}

