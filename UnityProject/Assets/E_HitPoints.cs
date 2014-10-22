using UnityEngine;
using System.Collections;

public class E_HitPoints : MonoBehaviour {

	// Use this for initialization
	public int HitPoints;
	
	// Update is called once per frame
	void GetDamage(int Damage)
	{
		HitPoints -= Damage;
		if (HitPoints <= 0) {
			Destroy(gameObject);
		}
	}
}
