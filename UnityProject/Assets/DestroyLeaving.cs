using UnityEngine;
using System.Collections;

public class DestroyLeaving : MonoBehaviour {

	void OnTriggerExit (Collider other) {
		Destroy(other.gameObject);
	}
}
