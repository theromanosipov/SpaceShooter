using UnityEngine;
using System.Collections;


public class Shooter : MonoBehaviour {

	public GameObject shot;
	public Transform[] shotSpawns;
	
	public int shotCount;
	public float delayShotSpwan;
	public float delayShotSeries;
	public float firstShotDelay;
	private float nextSeriesShoot;
	
	void Start() 
	{
		nextSeriesShoot = Time.time+firstShotDelay;
		}

	void Update () {
		if (Time.time >= nextSeriesShoot) {StartCoroutine(StartShooting()); nextSeriesShoot=Time.time+delayShotSeries;}
	}
	IEnumerator StartShooting()
	{
		for (int i=0; i <shotCount; i++) 
		{
			foreach(Transform shotspawn in shotSpawns)
			{
				Instantiate(shot, shotspawn.position, shotspawn.rotation);
			}
			yield return new WaitForSeconds(delayShotSpwan);
		}		
	}

}
