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
		nextWave = Time.time + timers [timerTracker];
	}

	void FixedUpdate ()
	{
		if (Time.time > nextWave&&timerTracker < timers.Length) 
		{
			gameObject.SendMessage ("Level" + timerTracker);
			timerTracker++;
			if (timerTracker < timers.Length) 
				nextWave=Time.time+timers[timerTracker];
		}
	}
	
	void SpawnRow(GameObject prefab, int count)
	{
		count--;
		for (int i=0; i<=count; i++)
		{
			SpawnOne (prefab,XValues[0]+1+i*(XValues[1]-XValues[0]-2)/count,YValue);
		}
	}

	void SpawnSymmetrically(GameObject prefab, float x, float y)
	{
		SpawnOne (prefab, x, y);
		SpawnOne (prefab, -x, y);
	}


	void SpawnRandom(GameObject prefab, float xmin, float xmax, float y)
	{
		SpawnOne (prefab, Random.Range (xmin, xmax), y);
	}

	void SpawnOne(GameObject prefab, float x, float y)
	{
		Instantiate (prefab, new Vector3(x,y,0), Quaternion.identity);
	}

	IEnumerator Level0 ()
	{
		isLevelEnabled [0] = true;

		float delay=0.4f;	
		while (!gameOver&&isLevelEnabled[0]) 
		{
			SpawnRandom (enemyPrefabs[0],XValues[0],XValues[1],YValue);
			yield return new WaitForSeconds(delay);
		}
	}

	IEnumerator Level1 ()
	{
		isLevelEnabled [1] = true;

		float delay=2f;	
		int shieldCount=15;
		SpawnSymmetrically (enemyPrefabs [3], XValues [0] / 2, YValue);
		SpawnRow (powerupPrefabs [4], shieldCount);
		while (!gameOver&&isLevelEnabled[1]) 
		{
			SpawnRandom (enemyPrefabs[1],XValues[0],XValues[1],YValue);
			yield return new WaitForSeconds(delay);
		}
	}
		
	void Level2()
	{
		isLevelEnabled [2] = true;

		//isLevelEnabled [1] = false;
		SpawnSymmetrically (enemyPrefabs [4], XValues [0] / 2, YValue);
		SpawnOne (powerupPrefabs [0], 0.75f * XValues [0], YValue);
		SpawnOne (powerupPrefabs [1], 0.25f * XValues [0], YValue);
		SpawnOne (powerupPrefabs [2], 0.25f * XValues [1], YValue);
		SpawnOne (powerupPrefabs [3], 0.75f * XValues [1], YValue);

	}

	void Level3()
	{
		isLevelEnabled [3] = true;

		SpawnRow (enemyPrefabs [5], 6);
		gameObject.SendMessage ("Level1");
	}

	void Level4()
	{
		isLevelEnabled [4] = true;
		
		SpawnRow (enemyPrefabs [6], 6);
		gameObject.SendMessage ("Level0");
		gameObject.SendMessage ("Level0");
	}
	

}



