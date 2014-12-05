using UnityEngine;
using System.Collections;

public class LevelSpawner1 : LevelSpawner {

    IEnumerator Level0()
    {
        isLevelEnabled[0] = true;
    
        float delay = 0.289575f;
        while (!isGameOver && isLevelEnabled[0])
        {
            SpawnRandom(enemyPrefabs[0], XValues[0], XValues[1], YValue);
            yield return new WaitForSeconds(delay);
        }
    }

    IEnumerator Level1()
    {
        isLevelEnabled[1] = true;

        float delay = 9.2664093f/4;
        while (!isGameOver && isLevelEnabled[1])
        {
			SpawnRow(powerupPrefabs[Mathf.FloorToInt(Random.Range(0f, powerupPrefabs.Length - 0.1f))], 10);
            yield return new WaitForSeconds(delay);
            SpawnRow(enemyPrefabs[3], 5);
            yield return new WaitForSeconds(delay);
        }
    }

    IEnumerator Level2()
    {
        isLevelEnabled[2] = true;
    
        float delay = 12.162162f;
        while (!isGameOver && isLevelEnabled[2])
        {
            SpawnSymmetrically(enemyPrefabs[1], 15, 15);
            yield return new WaitForSeconds(delay);
        }
    }

    IEnumerator Level3()
    {
        isLevelEnabled[3] = true;

        Vector2[] destination = new Vector2[2];
        destination[0] = new Vector2(30, 18);
        destination[1] = new Vector2(-30, -18);
        float delay = 10.42471f;

        while (!isGameOver && isLevelEnabled[3])
        {
            GameObject currentEnemy = Instantiate(enemyPrefabs[2]) as GameObject;
            currentEnemy.GetComponent<PointArrayMover>().SetDestination(destination);
            yield return new WaitForSeconds(delay);
        }
    }
    void Level4()
    {
        gameObject.SendMessage("Level0");
        gameObject.SendMessage("Level0");
    }
    void Level5()
    {
        isGameOver = true;
    }
}
