using UnityEngine;
using System.Collections;

public class EnemyRemoveInvincibility : MonoBehaviour {
	public EnemyInfo abcd;
	// Use this for initialization
	void Update () 
	{
		if (transform.childCount == 0) {
						abcd = gameObject.GetComponent<EnemyInfo> ();
						abcd.isInvincible = false;
						
				}
	}
}
