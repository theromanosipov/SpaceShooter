using UnityEngine;
using System.Collections;
/// <summary>
/// EnemyShip Nr5. mover'is.
/// Viliaus
/// </summary>

public class EnemyMover : MonoBehaviour {
	
	public float speeddown;				//Kokiu greičiu leidžiasi laivas.
	public float hspeed;				//Kokiu greičiu laivas juda horizontaliai
	public float xmin;					//riba
	public float xmax;					//riba
	public float ymin;
	public float ymax;
	public float wait;					//Kas kiek laiko laivas juda horizontaliai
	public float mtime;					//Kiek laiko laivas juda horizontaliai
	public GameObject shotspawnscenter;	//Laivo vaikas, kuriam priklauso visi shotSpawn'ai
	public float rotationSpeed;			//Kokiu greičiu sukame shotspawnscenter	
	public float exitTime;
	public float exitSpeed=20;
	private bool isExitTriggered=false;
	private float p;					//Tikimybė, kad laivas judės į kairę
	private float nextmove;				//Laikas, kada kitą kartą judės laivas horizontaliai
	private float random;				//Random skaičius, kuris nusprendžia į kurią pusę judės laivas.
	private float exitStartTime;
	
	
	void Start()
	{
		rigidbody2D.velocity = -speeddown*transform.up;
		nextmove = Time.time +wait;
		exitStartTime = Time.time + exitTime;
	}
	
	void Update () {
		if (Time.time > exitStartTime&&!isExitTriggered) {
			isExitTriggered=true;
			rigidbody2D.velocity=Random.insideUnitCircle*20;
				}
		if (Time.time >= nextmove&&!isExitTriggered) 
		{
			StartCoroutine(changevelocity ());
			nextmove=Time.time+wait;
			
		}
		
	}
	void FixedUpdate () {
		shotspawnscenter.gameObject.transform.Rotate(0.0f,rotationSpeed,0f);
	}
	
	IEnumerator changevelocity()
	{
		float s;
		s = transform.position.x;
		p = 4*Mathf.Pow(s,3)/Mathf.Pow ((xmax - xmin),3)+0.5f;
		random = Random.Range (0f,1f);
		if (random < p) {rigidbody2D.velocity += new Vector2(-hspeed,0f);}
		else {rigidbody2D.velocity += new Vector2(hspeed,0f);}
		yield return new WaitForSeconds(mtime);		
		if (!isExitTriggered)
		rigidbody2D.velocity = -speeddown*transform.up;
	}
}
