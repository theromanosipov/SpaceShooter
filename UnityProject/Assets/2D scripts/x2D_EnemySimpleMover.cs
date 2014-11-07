using UnityEngine;
using System.Collections;
/// <summary>
/// 
/// Justo
/// </summary>

public class x2D_EnemySimpleMover : MonoBehaviour {
	
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
		rigidbody2D.velocity = -speeddown*transform.up;
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
		rigidbody2D.position = new Vector2 (
			Mathf.Clamp (rigidbody2D.position.x, xmin, xmax),
			rigidbody2D.position.y
			);
	}
	IEnumerator changevelocity()
	{
		if (p == 1) 
		{
			rigidbody2D.velocity += new Vector2(-hspeed,0f);
			p = 0;
		}
		else 
		{
			rigidbody2D.velocity += new Vector2(hspeed,0f);
			p = 1;
		}
		yield return new WaitForSeconds(mtime);		
		rigidbody2D.velocity = -speeddown*transform.up;
	}
}
