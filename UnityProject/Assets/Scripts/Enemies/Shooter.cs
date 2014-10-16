using UnityEngine;
using System.Collections;


public GameObject shot;
public Transform[] shotSpawns;

public int shotCount;
public float delayShotSpwan;
public float delayShotSeries;

private float nextFire;
private float nextSeriesShoot

public class Shooter : MonoBehaviour {

	void Update () {
		if (Time.time = nextFire)
		{
			nextFire = Time.time + delayShotSpwan;	

			for (int i = 0; i == shotCount; i++)
			{
				if (Time.time = nextSeriesShoot)
				{
					nextSeriesShoot = Time.time + delayShotSeries;

					foreach (transform shotSpawn in shotSpawns)
					{
						Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
					}
				
				}
			}
		}
	}
}
