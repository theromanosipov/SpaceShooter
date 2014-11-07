using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary2 {
	public float xMin, xMax, yMin, yMax;
}

public class x2D_PlayerController : GenericPlayerController {

	public float speed;
	public Boundary2 boundary;
	public GameObject meele;
	public GameObject dock;
	public GameObject hitPointsText;
	private GameObject pMeele;
	private GameObject pDock;
	private GameObject phitPointsText;

	// Use this for initialization
	void Start () {
		pDock = Instantiate (dock, transform.position, Quaternion.identity) as GameObject;
		pDock.transform.parent = transform;
		phitPointsText = Instantiate (hitPointsText, new Vector3(transform.position.x,transform.position.y-1,transform.position.z-3),Quaternion.identity) as GameObject;
		phitPointsText.transform.parent = transform;
		pMeele = Instantiate (meele, transform.position, Quaternion.identity) as GameObject;
		pMeele.transform.parent = transform;	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rigidbody2D.velocity = new Vector2 (player.GetAxisH (), player.GetAxisV ());
		rigidbody2D.velocity.Normalize ();
		rigidbody2D.velocity = rigidbody2D.velocity * speed;
		
		rigidbody2D.position = new Vector2 (
			Mathf.Clamp (rigidbody2D.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp (rigidbody2D.position.y, boundary.yMin, boundary.yMax));
		phitPointsText.GetComponent<TextMesh>().text =""+player.GetHitPoints();
		

	}
}
