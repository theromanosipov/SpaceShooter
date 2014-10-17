using UnityEngine;
using System.Collections;

public class SimpleMover : MonoBehaviour {


	public Transform[] path;
	
	float t = 0;
	
	// Update is called once per frame
	void Update () {
		transform.position = Spline.MoveOnPath (path, transform.position, ref t, 0.5f); // Sudelijus path masyva jis vaikscios tuo keliu...
		
	}
}
