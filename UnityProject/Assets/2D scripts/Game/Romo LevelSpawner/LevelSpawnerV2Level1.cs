using UnityEngine;
using System.Collections;

public class LevelSpawnerV2Level1 : LevelSpawnerV2 {

	IEnumerator WaveSpinners( int currentBeat) {
        Vector2[] destination = new Vector2[2];
        destination[0] = new Vector2(28.9f, 16.1f);
        destination[1] = new Vector2(-30, -18);
        int delay = 8;

        while (!isGameOver && currentBeat + delay <= beatTime.Length) {
            GameObject currentEnemy = Instantiate(enemyPrefabs[0]) as GameObject;
            currentEnemy.GetComponent<PointArrayMover>().SetDestination(destination);
            currentBeat += delay;
            int iSample = (int)(beatTime[currentBeat - 1] * audio.clip.frequency);            // Gauna norimo samplo numerį
            while (audio.timeSamples < iSample) yield return 0;                               // Laukia norimo audio samplo
        }
    }
}
