using UnityEngine;
using System.Collections;
/// <summary>
/// Skydo sferos script'as. Aprašo spalvos pasikeitimą, gyvybes ir sunaikinimą. Turi GetDamage metodą;
/// </summary>
public class ShieldSphere : MonoBehaviour {

	public int HitPoints;		//Kiek mūsų sfera turi gyvybių
	public float colorResetTime;//Per kiek laiko spalva atistatys
	private float resetTime;	

	void Update(){
		if (Time.time >= resetTime) {
			gameObject.renderer.material.color = new Color(0f,1f,1f);}
	}

	void GetDamage(int Damage)
	{
		gameObject.renderer.material.color = new Color(1f,0,0);
		resetTime = Time.time + colorResetTime;
		HitPoints -= Damage;
		if (HitPoints <= 0) {
			Destroy(gameObject);
		}
	}
}
