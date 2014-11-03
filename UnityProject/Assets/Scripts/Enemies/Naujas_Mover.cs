using UnityEngine;
using System.Collections;
/// <summary>
/// Mover script'as. Jo esmė ta, kad greitis ekrano centre yra 
/// didesnis nei ekrano kraštuose, ir pasiekęs ekrano kraštą persirikiuoja į kitą ekrano pusę.
/// Viliaus
/// </summary>
public class Naujas_Mover : MonoBehaviour {

	public float speeddown; //Vertikalus greitis
	public float traveltime;//Kiek laiko užtrunka įveikti atkarpą
	public float waittime;  //Kas kiek laiko pradeda įveikinėti atkarpą. BŪTINAI turi būti didesnis, nei traveltime
	public float xmin;      //
	public float xmax;		//Ribos, kuriose vyksta judėjimas.
	public float ymin;		//
	public float ymax;		// y max gali būti mažesnis už viršutinę ribą -> kai laivas pateks tarp ymin ir ymax jis nebeišeis jau iš tų ribų
	private float nextmove; //Privatus kintamasis nusakantis laiką, kada kitą kartą judės. Time.time+waittime
	private float p;		//Kintamasis, kuris naudojamas nuspręsti į kurią pusę laivas judės.
	private float hspeed;	//Kintamasis, kokio greičiu jis judės atkarpą. 
							//Apskaičiuojamas: atstumas, kurį reikia įveikti padalinamas iš traveltime

	// Use this for initialization
	void Start () {
		rigidbody.velocity = -speeddown*transform.forward;
		nextmove += waittime;
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
			//Debug.Log ("Left");
			}
		else 
			{
			hspeed=(xmax-rigidbody.position.x)/(1.999f*traveltime);
			rigidbody.velocity = new Vector3(hspeed,0f,rigidbody.velocity.z);
			//Debug.Log ("Right");
			}
		yield return new WaitForSeconds(traveltime);		
		rigidbody.velocity = new Vector3(0f,0f,rigidbody.velocity.z);
		}

}
