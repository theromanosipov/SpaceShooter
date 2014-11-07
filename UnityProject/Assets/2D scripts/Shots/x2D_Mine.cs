using UnityEngine;
using System.Collections;

public class x2D_Mine : MonoBehaviour {
	
	public GameObject shot;
	public int shotCount;
	public int waveCount;
	public float delayWaveSpawn;
	private bool exploded = false;
	
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player"||other.tag=="Untagged"||other.tag=="Shield") {
			return;
		}
		if (exploded == false) {
			StartCoroutine(Explode ());
			exploded=true;	
		}
	}
	
	IEnumerator Explode(){
		Debug.Log ("Entered");
		for (int i=0; i <shotCount; i++) 
		{
			for (int j=0; j<waveCount; j++)
				Instantiate(shot, transform.position, Quaternion.Euler(0,0,Random.Range (0f,360f)));			;
			yield return new WaitForSeconds(delayWaveSpawn);
		}	
		Destroy (gameObject);
	}
}
