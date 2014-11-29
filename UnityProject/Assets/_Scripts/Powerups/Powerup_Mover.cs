using UnityEngine;
using System.Collections;

public class Powerup_Mover : MonoBehaviour
{
	public float speed;
		// Use this for initialization
		void Start ()
		{
			rigidbody2D.velocity = new Vector2 (0, -speed);
		}
}

