using UnityEngine;
using System.Collections;


public class EMover : MonoBehaviour {

	public float speeddown;
	public float hspeed;
	public float xmin;
	public float xmax;
	public float wait;
	public float mtime;
	public GameObject shotspawnscenter;
	public float rotationSpeed;
	private float p;
	private float nextmove;
	private float random;


	void Start()
	{
		rigidbody.velocity = -speeddown*transform.forward;
		nextmove += wait;
	}

	void Update () {
		if (Time.time >= nextmove) 
		{
			StartCoroutine(changevelocity ());
			nextmove=Time.time+wait;

		}
		rigidbody.position = new Vector3 (
			Mathf.Clamp (rigidbody.position.x, xmin, xmax),
			0.0f,
			rigidbody.position.z);

	}
	void FixedUpdate () {
		shotspawnscenter.gameObject.transform.Rotate(0.0f,rotationSpeed,0.0f);
	}

	IEnumerator changevelocity()
	{
		float s;
		s = transform.position.x;
		p = 4*((s)*(s)*(s))/((xmax - xmin)*(xmax - xmin)*(xmax - xmin))+0.5f;
		random = Random.Range (0f,1f);
		if (random < p) {rigidbody.velocity += new Vector3(-hspeed,0f,0f);}
		else {rigidbody.velocity += new Vector3(hspeed,0f,0f);}
		yield return new WaitForSeconds(mtime);		
		rigidbody.velocity = -speeddown*transform.forward;
	}
}
