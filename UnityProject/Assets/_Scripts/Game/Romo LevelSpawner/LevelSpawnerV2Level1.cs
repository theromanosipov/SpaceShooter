using UnityEngine;
using System.Collections;

public class LevelSpawnerV2Level1 : LevelSpawnerV2 {

    public float wallSpeed;
    public Vector3[] wallPosition;
    public Color[] wallColors;

	IEnumerator WaveSpinners( int currentBeat) {
        Vector2[] destination = new Vector2[2];
        destination[0] = new Vector2(27.1f, 15.38f);
        destination[1] = new Vector2(-30, -18);
        int delay = 1;

        while (!isGameOver && currentBeat + delay <= beatTime.Length) {
            GameObject currentEnemy = Instantiate(enemyPrefabs[0]) as GameObject;
            currentEnemy.GetComponent<PointArrayMover>().SetDestination(destination);
            currentBeat += delay;
            int iSample = (int)(beatTime[currentBeat - 1] * audio.clip.frequency);            // Gauna norimo samplo numerį
            while (audio.timeSamples < iSample) yield return 0;                               // Laukia norimo audio samplo
        }
    }

    IEnumerator DeathWallDown1(int currentBeat) {
        int delay = 1;

        int wallToSpawn = 0;                            // Iteratorius, kurį didinam iki wallPosition.Length ir tada nustojam spawnint sienas
        int colorNumber = 0;                            // Kitų sienų spalvų numeris wallColors masyve                  
        GameObject[] justSpawned = new GameObject[2];   // Dvi sienos, kuria spawnins


        while (!isGameOver && currentBeat + delay <= beatTime.Length && wallToSpawn < wallPosition.Length) {

            justSpawned[0] = Instantiate(enemyPrefabs[1], wallPosition[wallToSpawn], Quaternion.identity) as GameObject;                        // Spawnina pirmą sieną
            Vector3 secondWallOffset = new Vector3 (55, 0, 0);                                                                                  // Nustato koks bus antros sienos poslinkis lyginant su pirma siena
            justSpawned[1] = Instantiate(enemyPrefabs[1], wallPosition[wallToSpawn] + secondWallOffset, Quaternion.identity) as GameObject;     // Spawnina antrą sieną

            justSpawned[0].rigidbody2D.velocity = justSpawned[1].rigidbody2D.velocity = new Vector2(0, -wallSpeed);                             // Nustato sienų greitį
            justSpawned[0].renderer.material.color = justSpawned[1].renderer.material.color = wallColors[colorNumber];                          // Nustato sienų spalvą

            colorNumber++;
            if (colorNumber >= wallColors.Length)       // Užloopina spalvas, leidžia wallColors, būti mažesniam nei wallPosition
                colorNumber = 0;

            wallToSpawn++;
            
            currentBeat += delay;
            int iSample = (int)(beatTime[currentBeat - 1] * audio.clip.frequency);          // Gauna norimo samplo numerį
            while (audio.timeSamples < iSample) yield return 0;                             // Laukia norimo audio samplo
        }
    }
}
