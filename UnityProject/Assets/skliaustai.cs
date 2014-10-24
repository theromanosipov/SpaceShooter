using UnityEngine;
using System.Collections;

public class skliaustai : MonoBehaviour {

	// Use this for initialization
	public float speedVertical;
	public float HorizontaloConst;
	public float time0;
	private float starttime;	
	void Start () {
		starttime = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float vel = -HorizontaloConst/100+HorizontaloConst * ((Time.time - starttime) - time0) * ((Time.time - starttime) - time0) * ((Time.time - starttime) - time0)/10;
		rigidbody.velocity = new Vector3(-vel,0.0f,speedVertical);
	}
}
