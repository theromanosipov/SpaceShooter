using UnityEngine;
using System.Collections;

[System.Serializable]
public class Wave {
    public int timer;                       // Ant, kurio beato kvies metodą 1, 2, 3 ir tt.
    public string waveMethodName;
    public bool isEnabled = true;
}

/// <summary>
/// Pagal muziką kviečia metodus, kurie spawnina priešus (gal draugus, gimines, Salvadorą Dalį, žirafas, bananus)
/// </summary>
public class LevelSpawnerV2 : MonoBehaviour {
    public float spawnXMin;
    public float spawnXMax;
    public float spawnY;
    public GameObject[] enemyPrefabs;
    protected bool isGameOver = false;			//if true turėtų išsijungti visi ciklai
    public Wave[] wave;

    protected float[] beatTime = RythmUtility.getBeatArray();

    void Start() {
        StartCoroutine(CallOnAudioBeat());
    }

    // Į beatą kviečia kitus metodus, kurie spawnina priešus
    IEnumerator CallOnAudioBeat() {
        for (int i = 0; i < wave.Length; i++) {
            if (isGameOver)
                yield return 0;

            int iSample = (int)(beatTime[wave[i].timer - 1] * audio.clip.frequency);            // Gauna norimo samplo numerį
            while (audio.timeSamples < iSample) yield return 0;                                 // Laukia norimo audio samplo
            if(wave[i].isEnabled)
                gameObject.SendMessage(wave[i].waveMethodName, wave[i].timer);              // Kviečia spawninimo metodą. Perduoda per, kurį beatą buvo iškviestas metodas
        }
    }

    protected void SpawnRow(GameObject prefab, int count) {
        count--;
        for (int i = 0; i <= count; i++) {
            SpawnOne(prefab, spawnXMin + 1 + i * (spawnXMax - spawnXMin - 2) / count, spawnY);
        }
    }

    protected void SpawnSymmetrically(GameObject prefab, float x, float y) {
        SpawnOne(prefab, x, y);
        SpawnOne(prefab, -x, y);
    }

    protected void SpawnRandom(GameObject prefab, float xmin, float xmax, float y) {
        SpawnOne(prefab, Random.Range(xmin, xmax), y);
    }

    protected void SpawnOne(GameObject prefab, float x, float y) {
        Instantiate(prefab, new Vector3(x, y, 0), Quaternion.identity);
    }




}
