using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

	public int sphereCount;
	public GameObject sphere;
	public float distance;
	public float rotationSpeed;
	private GameObject Sphere;
	private Vector3 spherePosition;
	private float angle;
	// Use this for initialization
	void Start () {
		angle = 0;
		for (int i=0; i<sphereCount;i++){
			angle += 2*3.14f/sphereCount;
			spherePosition=transform.position+distance*new Vector3 (Mathf.Sin (angle), 0.0f, Mathf.Cos (angle));
			Sphere=Instantiate(sphere, spherePosition, Quaternion.identity) as GameObject;
			Sphere.transform.parent = transform;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		gameObject.transform.Rotate(0.0f,rotationSpeed,0.0f);
		if (transform.childCount == 0) {
						Destroy (gameObject);
				}
	}
}
