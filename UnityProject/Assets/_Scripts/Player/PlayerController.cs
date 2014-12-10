using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary2 {
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : GenericPlayerController {

	public float speed;
	public Boundary2 boundary;
	public GameObject meele;
	public GameObject hitPointsText;
	private GameObject pMeele;
	private GameObject phitPointsText;
	private GameObject pScoreText;

	// Use this for initialization
	void Start () {
		phitPointsText = Instantiate (hitPointsText, new Vector3(transform.position.x,transform.position.y-1.5f,transform.position.z-3),Quaternion.identity) as GameObject;
		phitPointsText.transform.parent = transform;
		pScoreText = Instantiate (hitPointsText, new Vector3(transform.position.x,transform.position.y-2.5f,transform.position.z-3),Quaternion.identity) as GameObject;
		pScoreText.transform.parent = transform;
		pMeele = Instantiate (meele, transform.position, Quaternion.identity) as GameObject;
		pMeele.transform.parent = transform;	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rigidbody2D.velocity = new Vector2 (player.GetAxisH ()*speed, player.GetAxisV ()*speed);
		//if (rigidbody2D.velocity.magnitude > speed) {
		//				rigidbody2D.velocity.Normalize ();
		//				rigidbody2D.velocity = rigidbody2D.velocity * speed;
		//		}
		
		rigidbody2D.position = new Vector2 (
			Mathf.Clamp (rigidbody2D.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp (rigidbody2D.position.y, boundary.yMin, boundary.yMax));
		phitPointsText.GetComponent<TextMesh>().text =""+player.GetHitPoints();
		pScoreText.GetComponent<TextMesh>().text =""+player.GetScore();
		

	}
}
