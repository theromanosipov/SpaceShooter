using UnityEngine;
using System.Collections;
/// <summary>
/// Ganėtinai universalus priešų šaudymo script'as
/// Viliaus
/// </summary>

public class E_Shooter : MonoBehaviour {

	public GameObject shot;			//Šūvio model'io prefabas (Šūvis turi turėti savo judėjimą aprašytą viduj)
	public Transform[] shotSpawns;	//Masyvas shotSpawn'ų iš kurių šaudys
	
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
			foreach(Transform shotspawn in shotSpawns)
			{
				Instantiate(shot, shotspawn.position, shotspawn.rotation);
			}
			yield return new WaitForSeconds(delayShotSpwan);
		}		
	}

}
