using UnityEngine;
using System.Collections;
/// <summary>
/// Script'as sunaikinantis objektus paliekančius žaidimo erdvę.
/// Kartais sunaikina tai, ko neturėtų -> bet priežasties nežinau
/// </summary>
public class DestroyLeaving : MonoBehaviour {
	
	void OnTriggerExit2D (Collider2D other) {Destroy(other.gameObject);}
}
