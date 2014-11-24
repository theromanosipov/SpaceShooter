using UnityEngine;
using System.Collections;

public class LevelSpawner : MonoBehaviour
{
    public float[] XValues;				    //XMIN XMAX
    public float YValue;				    //YMAX
    public float[] timers;				    //po kiek laiko spawnins lygį	
    public GameObject[] enemyPrefabs;
    public GameObject[] powerupPrefabs;
    public bool isGameOver = false;			//if true turėtų išsijungti visi ciklai
    public bool[] isLevelEnabled;		    //if false - tas lygis turėtų išsijungti
    protected float nextWave = 0;
    protected int timerTracker = 0;

    void Start()
    {
        nextWave = Time.time + timers[timerTracker];
    }

    void FixedUpdate()
    {
        if (Time.time > nextWave && timerTracker < timers.Length)
        {
            gameObject.SendMessage("Level" + timerTracker);
            timerTracker++;
            if (timerTracker < timers.Length)
                nextWave = Time.time + timers[timerTracker];
        }
    }

    protected void SpawnRow(GameObject prefab, int count)
    {
        count--;
        for (int i = 0; i <= count; i++)
        {
            SpawnOne(prefab, XValues[0] + 1 + i * (XValues[1] - XValues[0] - 2) / count, YValue);
        }
    }

    protected void SpawnSymmetrically(GameObject prefab, float x, float y)
    {
        SpawnOne(prefab, x, y);
        SpawnOne(prefab, -x, y);
    }

    protected void SpawnRandom(GameObject prefab, float xmin, float xmax, float y)
    {
        SpawnOne(prefab, Random.Range(xmin, xmax), y);
    }

    protected void SpawnOne(GameObject prefab, float x, float y)
    {
        Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity);
    }

    


}