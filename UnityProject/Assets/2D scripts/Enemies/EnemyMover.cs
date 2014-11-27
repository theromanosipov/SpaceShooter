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
	public float wait;					//Kas kiek laiko laivas juda horizontaliai
	public float mtime;					//Kiek laiko laivas juda horizontaliai
	public GameObject shotspawnscenter;	//Laivo vaikas, kuriam priklauso visi shotSpawn'ai
	public float rotationSpeed;			//Kokiu greičiu sukame shotspawnscenter	
	private float p;					//Tikimybė, kad laivas judės į kairę
	private float nextmove;				//Laikas, kada kitą kartą judės laivas horizontaliai
	private float random;				//Random skaičius, kuris nusprendžia į kurią pusę judės laivas.
	
	
	void Start()
	{
		rigidbody2D.velocity = -speeddown*transform.up;
		nextmove += wait;
	}
	
	void Update () {
		if (Time.time >= nextmove) 
		{
			StartCoroutine(changevelocity ());
			nextmove=Time.time+wait;
			
		}
		transform.position = new Vector3 (
			Mathf.Clamp (rigidbody2D.position.x, xmin, xmax),
			rigidbody2D.position.y,
			0);
		
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
		rigidbody2D.velocity = -speeddown*transform.up;
	}
}
