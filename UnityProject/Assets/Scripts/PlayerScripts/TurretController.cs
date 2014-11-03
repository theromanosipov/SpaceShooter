using UnityEngine;
using System.Collections;
/// <summary>
/// Turret Controller script'as
/// Viliaus
/// </summary>
public class TurretController : GenericPlayerController {

	public float speed;				//Sukimosi greitis
	public float distance;			//Kokiu atstumu nuo įtvirtinimo taško juda bokštas
	public bool isDistanceLocked;	//Jei true, tai atstumas nuo tėvo konstanta, jei ne, galima keisti minDistance maxDistance ribose
	public float minDistance;		//Minimalus atstumas, kuriuo gali būti bokštas nuo tėvo
	public float maxDistance;		//Maksimalus atstumas, kuriuo gali būti bokštas nuo tėvo
	public float speedDistance;		//Kaip greitai galima keisti atstumą.
	private float angle;			//dabartinę bokšto poziciją nusakantis dydis
	private bool isRotationClamped;	//if false -> bokštelis sukasi 360 deg, if true reik nurodyt min ir max Angle.
	private float minAngle;			//Dydžiai naudojami 
	private float maxAngle;			// 				apriboti bokštelio sukimąsi
	void Start() {
		angle = 0;
		isRotationClamped = false;
	}
	void FixedUpdate () {
		angle += 3.14f/180f*speed * player.GetAxisH ();
		if (angle >= 6.283185f) {
			angle-=6.283185f;}
		if (angle <= 0f) {
			angle+=6.283185f;}
		if (isRotationClamped) {
			Mathf.Clamp (angle,minAngle,maxAngle);
				}
		if (!isDistanceLocked) {
			distance+=player.GetAxisV()*speedDistance;
			distance=Mathf.Clamp(distance,minDistance,maxDistance);
				}
		transform.position = transform.parent.position+distance*new Vector3 (Mathf.Sin (angle), 0.0f, Mathf.Cos (angle));
		transform.rotation = Quaternion.Euler (90f, angle*180f/3.14f, 0f);
		Debug.Log ("Rotation restored");
	}

	public void RestrictRotation(float minAngle, float maxAngle) {
		isRotationClamped = true;
		this.minAngle = minAngle;
		this.maxAngle = maxAngle;
	}

}
