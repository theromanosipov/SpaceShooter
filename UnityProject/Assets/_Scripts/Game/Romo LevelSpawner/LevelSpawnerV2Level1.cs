using UnityEngine;
using System.Collections;

[System.Serializable]
public class WallInfo {
    public float wallSpeedX;
    public float wallSpeedY;
    public Vector3 rotation;
    public Vector3[] wallPosition;
    public Color[] wallColors;
    public int delay;
}

[System.Serializable]
public class PointArrayInfo {
    public Vector2[] pointArray;
    public GameObject gameObject;
}

public class LevelSpawnerV2Level1 : LevelSpawnerV2 {

    public WallInfo Wall1;
    public WallInfo Wall2;
    public WallInfo Wall3;

    public void SpawnWall1(int currentBeat) {
        StartCoroutine(SpawnDeathWall(currentBeat, Wall1));
    }

    public void SpawnWall2(int currentBeat) {
        StartCoroutine(SpawnDeathWall(currentBeat, Wall2));
    }

    public void SpawnWall3(int currentBeat) {
        StartCoroutine(SpawnDeathWall(currentBeat, Wall3));
    }

    IEnumerator SpawnDeathWall(int currentBeat, WallInfo wallInfo) {

        int wallToSpawn = 0;                            // Iteratorius, kurį didinam iki wallPosition.Length ir tada nustojam spawnint sienas
        int colorNumber = 0;                            // Kitų sienų spalvų numeris wallColors masyve                  
        GameObject justSpawned;


        while (!isGameOver && currentBeat + wallInfo.delay <= beatTime.Length && wallToSpawn < wallInfo.wallPosition.Length) {

            justSpawned = Instantiate(enemyPrefabs[1], wallInfo.wallPosition[wallToSpawn], Quaternion.identity) as GameObject;      // Spawnina pirmą sieną

            justSpawned.rigidbody2D.velocity = new Vector2(wallInfo.wallSpeedX, wallInfo.wallSpeedY);       // Nustato sienų greitį
            justSpawned.renderer.material.color = wallInfo.wallColors[colorNumber];                         // Nustato sienų spalvą
            justSpawned.transform.localEulerAngles = wallInfo.rotation;

            colorNumber++;
            if (colorNumber >= wallInfo.wallColors.Length)       // Užloopina spalvas, leidžia wallColors, būti mažesniam nei wallPosition
                colorNumber = 0;

            wallToSpawn++;
            
            currentBeat += wallInfo.delay;
            int iSample = (int)(beatTime[currentBeat - 1] * audio.clip.frequency);          // Gauna norimo samplo numerį
            while (audio.timeSamples < iSample) yield return 0;                             // Laukia norimo audio samplo
        }
    }

    public PointArrayInfo pointInfo1;
    public PointArrayInfo pointInfo2;

    public void SpawnPointArrayMover1(int currentBeat) {
        SpawnPointArrayMover(pointInfo1);
    }

    public void SpawnPointArrayMover2(int currentBeat) {
        SpawnPointArrayMover(pointInfo2);
    }

    public void SpawnPointArrayMover(PointArrayInfo pointInfo) {
        GameObject currentEnemy = Instantiate(pointInfo.gameObject) as GameObject;
        currentEnemy.GetComponent<PointArrayMover>().SetDestination(pointInfo.pointArray);    
    }

    public GameObject[] spawnRandomPrefabs;
	public float spawnX;

    IEnumerator SpawnRandom(int currentBeat) {
        Debug.Log("SpawnRandom");
        int k = 0;
        while (k < 10) {
            int j = Mathf.FloorToInt(Random.Range(0f, spawnRandomPrefabs.Length));
            for (int i = 0; i < Random.Range(0f, 5.99f); i++) {
                float x = Random.Range(-spawnX, spawnX);
                GameObject spawnedNow = Instantiate(spawnRandomPrefabs[j], new Vector3(x, spawnY, 0), Quaternion.identity) as GameObject;
            }
            k++;
            float nextSpawnTime = Time.time + 1;
            while (Time.time < nextSpawnTime) yield return 0;
        }
    }
}
