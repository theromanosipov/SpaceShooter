using UnityEngine;
using System.Collections;
/// <summary>
/// Mover script'as. Jo esmė ta, kad greitis ekrano centre yra 
/// didesnis nei ekrano kraštuose, ir pasiekęs ekrano kraštą persirikiuoja į kitą ekrano pusę.
/// Viliaus
/// </summary>
public class EnemyMover2 : MonoBehaviour {
	
	public float speeddown; //Vertikalus greitis
	public float traveltime;//Kiek laiko užtrunka įveikti atkarpą
	public float waittime;  //Kas kiek laiko pradeda įveikinėti atkarpą. BŪTINAI turi būti didesnis, nei traveltime
	public float xmin;      //
	public float xmax;		//Ribos, kuriose vyksta judėjimas.
	public float ymin;		//
	public float ymax;		// y max gali būti mažesnis už viršutinę ribą -> kai laivas pateks tarp ymin ir ymax jis nebeišeis jau iš tų ribų
	public float exitTime;
	public float exitSpeed=20;
	private bool isExitTriggered=false;
	private float exitStartTime;
	private float nextmove; //Privatus kintamasis nusakantis laiką, kada kitą kartą judės. Time.time+waittime
	private float p;		//Kintamasis, kuris naudojamas nuspręsti į kurią pusę laivas judės.
	private float hspeed;	//Kintamasis, kokio greičiu jis judės atkarpą. 
	//Apskaičiuojamas: atstumas, kurį reikia įveikti padalinamas iš traveltime
	
	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = -speeddown*transform.up;
		nextmove = Time.time +waittime;
		exitStartTime = Time.time + exitTime;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.time > exitStartTime&&!isExitTriggered) {
			isExitTriggered=true;
			rigidbody2D.velocity=Random.insideUnitCircle*20;
		}
		if (Time.time >= nextmove&&!isExitTriggered) 
		{
			StartCoroutine(changevelocity ());
			nextmove=Time.time+waittime;
			
		}
		if ((rigidbody2D.position.y<=ymin)&&(speeddown>0f)&&!isExitTriggered)
		{
			speeddown=-speeddown;
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,-rigidbody2D.velocity.y);
		}
		if ((rigidbody2D.position.y>=ymax)&&(speeddown<0f)&&!isExitTriggered)
		{
			speeddown=-speeddown;
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,-rigidbody2D.velocity.y);
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
			hspeed=(rigidbody2D.position.x-xmin)/(1.999f*traveltime);
			rigidbody2D.velocity = new Vector2(-hspeed,rigidbody2D.velocity.y);
			//Debug.Log ("Left");
		}
		else 
		{
			hspeed=(xmax-rigidbody2D.position.x)/(1.999f*traveltime);
			rigidbody2D.velocity = new Vector2(hspeed,rigidbody2D.velocity.y);
			//Debug.Log ("Right");
		}
		yield return new WaitForSeconds(traveltime);	
		if (!isExitTriggered)
		rigidbody2D.velocity = new Vector2(0f,rigidbody2D.velocity.y);
	}
	
}
