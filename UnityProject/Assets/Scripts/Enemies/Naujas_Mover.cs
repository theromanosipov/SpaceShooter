using UnityEngine;
using System.Collections;

public class Naujas_Mover : MonoBehaviour {

	public float speeddown;
	public float traveltime;
	public float waittime;
	public float xmin;
	public float xmax;
	public float ymin;
	public float ymax;
	private float nextmove;
	private float p;
	private float hspeed;
	private float power1;

	// Use this for initialization
	void Start () {
		rigidbody.velocity = -speeddown*transform.forward;
		nextmove += waittime;
		power1 = 7;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.time >= nextmove) 
		{
			StartCoroutine(changevelocity ());
			nextmove=Time.time+waittime;
			
		}
		if ((rigidbody.position.z<=ymin)&&(speeddown>0f))
		{
			speeddown=-speeddown;
			rigidbody.velocity = new Vector3(rigidbody.velocity.x,0f,-rigidbody.velocity.z);
		}
		if ((rigidbody.position.z>=ymax)&&(speeddown<0f))
		{
			speeddown=-speeddown;
			rigidbody.velocity = new Vector3(rigidbody.velocity.x,0f,-rigidbody.velocity.z);
		}
	}
	IEnumerator changevelocity()
	{

		if ((transform.position.x <= xmin * 0.85f)||((transform.position.x <= xmax*0.85f)&&(transform.position.x >= (xmin+xmax)/2))) {
						p = -1;
				} else {
						p = 1;
				}
		if (p==1) 
			{
			hspeed=(rigidbody.position.x-xmin)/(1.999f*traveltime);
			rigidbody.velocity = new Vector3(-hspeed,0f,rigidbody.velocity.z);
			Debug.Log ("Left");
			}
		else 
			{
			hspeed=(xmax-rigidbody.position.x)/(1.999f*traveltime);
			rigidbody.velocity = new Vector3(hspeed,0f,rigidbody.velocity.z);
			Debug.Log ("Right");
			}
		yield return new WaitForSeconds(traveltime);		
		rigidbody.velocity = new Vector3(0f,0f,rigidbody.velocity.z);
		}

}
