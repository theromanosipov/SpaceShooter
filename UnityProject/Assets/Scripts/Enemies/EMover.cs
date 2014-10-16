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
	private float p;
	private float nextmove;
	private float random;

	void Start()
	{
		rigidbody.velocity = -speeddown*transform.forward;
		nextmove += wait;
		shotspawnscenter.rigidbody.angularVelocity =new Vector3(0,4f,0);
	}

	void Update () {
		shotspawnscenter.rigidbody.position = rigidbody.position;
		if (Time.time >= nextmove) 
		{
			StartCoroutine(changevelocity ());
			nextmove=Time.time+wait;

		}

	}

	void FixedUpdate ()
	{
		rigidbody.position = new Vector3 (
			Mathf.Clamp (rigidbody.position.x, xmin, xmax),
			0.0f,
			rigidbody.position.z);
	}
	IEnumerator changevelocity()
	{
		//p = (transform.position.x - xmin)/(xmax - xmin);
		float s;
		s = transform.position.x;
		p = 4*((s)*(s)*(s))/((xmax - xmin)*(xmax - xmin)*(xmax - xmin))+0.5f;
		random = Random.Range (0f,1f);
		Debug.Log (p);
		//Debug.Log (random);
		if (random < p) {rigidbody.velocity += new Vector3(-hspeed,0f,0f);}
		else {rigidbody.velocity += new Vector3(hspeed,0f,0f);}
		yield return new WaitForSeconds(mtime);		
		rigidbody.velocity = -speeddown*transform.forward;
	}
}
