using UnityEngine;
using System.Collections;

public class DestroyLeaving : MonoBehaviour {

	void OnTriggerExit (Collider other) {
		if(other.tag=="Untagged"){Destroy(other.gameObject);}
	}
}
