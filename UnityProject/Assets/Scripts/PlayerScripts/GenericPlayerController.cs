using UnityEngine;
using System.Collections;

/// <summary>
/// Tėvinė player controller klasė
/// </summary>
public class GenericPlayerController : MonoBehaviour {

	protected PlayerInfoContainer player;
	
	public virtual void Update() {
        //Jei player == null gaunamas PlayerInfo iš PlayerInfoContainer
        if( player == null) {
            Debug.Log("Getting PlayerInfo");
			player = gameObject.GetComponentsInParent<PlayerInfoContainer>()[0];
		}
    }
}