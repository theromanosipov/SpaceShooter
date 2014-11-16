using UnityEngine;
using System.Collections;

public class Level_Spawner : MonoBehaviour
{
	public float[] XValues;				//XMIN XMAX
	public float YValue;				//YMAX
	public float[] timers;				//po kiek laiko spawnins lygį	
	public GameObject[] enemyPrefabs;	
	public GameObject[] powerupPrefabs;
	public bool gameOver=false;			//if true turėtų išsijungti visi ciklai
	public bool[] isLevelEnabled;		//if false - tas lygis turėtų išsijungti
	private float nextWave=0;
	private int timerTracker=0;
		
		void Start ()
		{
		for (int i=0; i<isLevelEnabled.Length; i++)
						isLevelEnabled[i] = true;
		nextWave = Time.time + timers [timerTracker];
		}
		// Update is called once per frame
		void FixedUpdate ()
		{
		if (Time.time > nextWave&&timerTracker < timers.Length) {
						gameObject.SendMessage ("Level" + timerTracker);
						timerTracker++;
						nextWave=Time.time+timers[timerTracker];
				}
		}
		IEnumerator Level0 ()
		{
		float delay=0.4f;	
		while (!gameOver&&isLevelEnabled[0]) {
				Instantiate (enemyPrefabs[0], new Vector3(Random.Range(XValues[0],XValues[1]),YValue,0), Quaternion.identity);
				yield return new WaitForSeconds(delay);
		}
		}
		IEnumerator Level1 ()
		{
		float delay=1f;	
		Instantiate (enemyPrefabs[3], new Vector3(XValues[0]/2,YValue,0), Quaternion.identity);
		Instantiate (enemyPrefabs[3], new Vector3(XValues[1]/2,YValue,0), Quaternion.identity);
		while (!gameOver&&isLevelEnabled[1]) {
			Instantiate (enemyPrefabs[1], new Vector3(Random.Range(XValues[0],XValues[1]),YValue,0), Quaternion.identity);
			yield return new WaitForSeconds(delay);
		}
	}
}

