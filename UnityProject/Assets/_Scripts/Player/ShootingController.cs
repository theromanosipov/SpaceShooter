using UnityEngine;
using System.Collections;

public class ShootingController : GenericPlayerController
{
	public GameObject shot;
	public Transform[] shotSpawns;
	public float fireRate;

    public bool givePlayerColor;

	private float scatter;
	public float scatterK;
	public float shotCount = 0;
	public float maxShots = 1;
	private float nextFire;

    private SpriteRenderer shipRenderer;

    void Start() {
        shipRenderer = renderer as SpriteRenderer;
    }
	
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
				GameObject bullet = Instantiate( shot, shotSpawn.position, 
				            Quaternion.Euler 
				            (shotSpawn.rotation.eulerAngles.x,
				 shotSpawn.rotation.eulerAngles.y,
				 shotSpawn.rotation.eulerAngles.z+Random.Range (-scatter,scatter))
				            ) as GameObject;
				bullet.BroadcastMessage("AssignPlayer", player);

                if (givePlayerColor) {
                    SpriteRenderer bulletRenderer = bullet.renderer as SpriteRenderer;
                    bulletRenderer.color = shipRenderer.color;
                }
			}
			shotCount--;
		}
	}
}

