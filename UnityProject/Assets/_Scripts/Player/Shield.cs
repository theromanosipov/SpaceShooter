using UnityEngine;
using System.Collections;
/// <summary>
/// Tėvinio skydo sferų objekto scriptas. Jo atsiradimo metu sukuriamos sferos.
/// Viliaus
/// </summary>
public class Shield : MonoBehaviour {
	
	public int sphereCount;			//Kiek sferų suksis apie mūsų laivą
	public GameObject sphere;		//Sferų prefab'as
	public float distance;			//Kokiu atstumu mūsų sferos suksis
	public float rotationSpeed;		//Kokiu greičiu suksis.
	private GameObject Sphere;		//Kintamasis naudojamas įvaikinti mūsų sferą skydo prefab'ui.
	private Vector3 spherePosition; //Instantiate'inamos sferos pozicija
	private float angle;			//Kintamasis naudojamas apskaičiuoti sferų pozicijas, kad jos būtų tolygiai pasiskirstę.
	// Use this for initialization
	void Start () {
		angle = 0;
		for (int i=0; i<sphereCount;i++){
			angle += 2*3.14f/sphereCount;
			spherePosition=transform.position+distance*new Vector3 (Mathf.Sin (angle), Mathf.Cos (angle),0f);
			Sphere=Instantiate(sphere, spherePosition, Quaternion.identity) as GameObject;
			Sphere.transform.parent = transform;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		gameObject.transform.Rotate(0.0f,0f,rotationSpeed);
		if (transform.childCount == 0) {
			Destroy (gameObject);
		}
	}
}
