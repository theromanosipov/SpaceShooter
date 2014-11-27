using UnityEngine;
using System.Collections;
/// <summary>
/// Ganėtinai universalus priešų šaudymo script'as
/// Viliaus
/// </summary>

public class EnemyShooter2 : MonoBehaviour {

	public GameObject shot;			//Šūvio model'io prefabas (Šūvis turi turėti savo judėjimą aprašytą viduj)
	public Vector3[] shotLocation;	//Masyvas shotSpawn'ų iš kurių šaudys
	public Vector3[] shotRotation;	
	public int shotCount;			//Kiek serijoje yra šūvių
	public float delayShotSpwan;	//Laiko tarpas tarp šūvių serijoje
	public float delayShotSeries;	//Kas kiek laiko paleidžiama serija
	public float firstShotDelay;	//Po kiek laiko nuo objekto atsiradimo pradės šaudyt	
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
			for (int j=0; j<shotLocation.Length; j++)
			{
				Instantiate(shot, transform.position+shotLocation[j], Quaternion.Euler (shotRotation[j]));
			}
			yield return new WaitForSeconds(delayShotSpwan);
		}		
	}

}
