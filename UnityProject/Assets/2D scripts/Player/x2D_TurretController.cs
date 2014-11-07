using UnityEngine;
using System.Collections;

public class x2D_TurretController : GenericPlayerController
{
	public float speed;				//Sukimosi greitis
	public float distance;			//Kokiu atstumu nuo įtvirtinimo taško juda bokštas
	public bool isDistanceLocked;	//Jei true, tai atstumas nuo tėvo konstanta, jei ne, galima keisti minDistance maxDistance ribose
	public float minDistance;		//Minimalus atstumas, kuriuo gali būti bokštas nuo tėvo
	public float maxDistance;		//Maksimalus atstumas, kuriuo gali būti bokštas nuo tėvo
	public float speedDistance;		//Kaip greitai galima keisti atstumą.
	private float angle=0;			//dabartinę bokšto poziciją nusakantis dydis
	//private bool isRotationClamped;	//if false -> bokštelis sukasi 360 deg, if true reik nurodyt min ir max Angle.
	private float minAngle;			//Dydžiai naudojami 
	private float maxAngle;			// 				apriboti bokštelio sukimąsi

		void FixedUpdate ()
		{
			angle += 3.14f/180f*speed * player.GetAxisH ();
			if (angle >= 6.283185f) {
				angle-=6.283185f;}
			if (angle <= 0f) {
				angle+=6.283185f;}
			//if (isRotationClamped) {
			//	Mathf.Clamp (angle,minAngle,maxAngle);
			//}
			if (!isDistanceLocked) {
				distance+=player.GetAxisV()*speedDistance;
				distance=Mathf.Clamp(distance,minDistance,maxDistance);
			}
			transform.position = transform.parent.position+distance*new Vector3 (Mathf.Sin (angle), Mathf.Cos (angle),0.0f);
			transform.rotation = Quaternion.Euler (0f, 0f,-angle*180f/3.14f);
		}
}

