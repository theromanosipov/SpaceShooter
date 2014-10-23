using UnityEngine;
using System.Collections;


public class SimpleMover2 : MonoBehaviour {
	
	public float speeddown;
	public float hspeed;
	public float xmin;
	public float xmax;
	public float wait;
	public float mtime;
	private float p;
	private float nextmove;
	
	
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
		float s;
		s = transform.position.x;
		if (p == 1) 
		{
			rigidbody.velocity += new Vector3(-hspeed,0f,0f);
			p = 0;
		}
		else 
		{
			rigidbody.velocity += new Vector3(hspeed,0f,0f);
			p = 1;
		}
		yield return new WaitForSeconds(mtime);		
		rigidbody.velocity = -speeddown*transform.forward;
	}
}
