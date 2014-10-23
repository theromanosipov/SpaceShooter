using UnityEngine;
using System.Collections;

/// <summary>
/// Tėvinė player controller klasė
/// </summary>
public class GenericPlayerController : MonoBehaviour {

	protected PlayerInfo player;
	
	public virtual void Update() {
        //Jei player == null gaunamas PlayerInfo iš PlayerInfoContainer
        if( player == null) {
            Debug.Log("Getting PlayerInfo");
			PlayerInfoContainer newPlayer = gameObject.GetComponentsInParent<PlayerInfoContainer>()[0];
            if( newPlayer == null) {
                Debug.Log("Failed GenericControllerInfo Update Can't find PlayerInfoContainer");
		    }
		    else {
                player = newPlayer.playerInfo;
		    }
	    }
    }
}