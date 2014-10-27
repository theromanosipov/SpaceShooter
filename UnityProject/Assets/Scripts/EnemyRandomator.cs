using UnityEngine;
using System.Collections;

public class EnemyRandomator : MonoBehaviour {

	public GameObject[] enemyPrefabs;
	public float spawnZ;
	public float spawnX;
	public float difficulty;
	private float challenge;
	void Start () {
		challenge = 0f;
	}

	void Update () {
		if (challenge < difficulty) {
			int j = Mathf.FloorToInt(Random.Range (0f, enemyPrefabs.Length));
			for(int i = 0; i < Random.Range(0f, 5.99f); i++){
				float x = Random.Range (-spawnX, spawnX);
				Instantiate (enemyPrefabs[j], new Vector3(x, 0f, spawnZ), new Quaternion());
				challenge++;
			}
		}
		challenge /= 1 + Time.deltaTime;
	}
}
