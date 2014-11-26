using UnityEngine;
using System.Collections;

public class LevelSpawner2 : LevelSpawner {

    IEnumerator Level0() {
        isLevelEnabled[0] = true;

        Vector2[] destination = new Vector2[2];
        destination[0] = new Vector2(30, 18);
        destination[1] = new Vector2(-30, -18);
        float delay = 10.42471f;

        while (!isGameOver && isLevelEnabled[0]) {
            GameObject currentEnemy = Instantiate(enemyPrefabs[0]) as GameObject;
            currentEnemy.GetComponent<PointArrayMover>().SetDestination(destination);
            yield return new WaitForSeconds(delay);
        }
    }
}
