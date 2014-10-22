using UnityEngine;
using System.Collections;

/// <summary>
/// Tėvinė player controller klasė
/// </summary>
public class GenericPlayerController : MonoBehaviour {

	protected PlayerInfo player;
	
	public virtual void Update() {
		RefreshPlayer();
	}
	
	public void RefreshPlayer() {
		PlayerInfo newPlayer = gameObject.GetComponent<PlayerInfo>();
		if( newPlayer != null) {
			player = newPlayer;
		}
		else {
			Debug.Log( "Failed RefreshPlayer() no PlayerInfo found");
		}
	}
}
