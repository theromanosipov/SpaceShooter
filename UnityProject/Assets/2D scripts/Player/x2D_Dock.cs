using UnityEngine;
using System.Collections;

/// <summary>
/// Dock skriptas skirtas dokui prie, kurio jungiasi laivas
/// </summary>
public class x2D_Dock : MonoBehaviour {
	
	// Jei turretas sukasi apie savo ašį, šie kintamieji apriboją jo sukimasį (radianais)
	// public float minTurretRotation, maxTurretRotation;
	
	// Reference į turreto PlayerInfoContainer, kad galėtume sužinoti, kada turretas nori atsijungti.
	private PlayerInfoContainer player;
	
	// Referencę į turretą, kad galėtume jį sunaikinti
	private GameObject turret = null;
	
	// False, kai doke yra turretas
	private bool isDockEmpty = true;
	
	// True, kai vyksta bet koks dokavimasis, neleidžia duokuotis vienu metu
	private static bool isDockingInProgress = false;
	
	void Update() {
		// Turretas sunaikinamas ir spawninamas laivas
		if (!isDockEmpty && !player.IsDockPause() && player.GetButtonDock())
		{
			player.SetDockPause(0.5f);
			
			Dockable dockable = turret.GetComponent<Dockable>();
			
			GameObject ship = Instantiate(dockable.otherForm, turret.transform.position, Quaternion.identity) as GameObject;
			ship.GetComponent<PlayerInfoContainer>().SetPlayerInfo( player.GetPlayerInfo());
			
			Destroy(turret);
			
			turret = null;
			isDockEmpty = true;
			
		}
	}
	
	void OnTriggerStay2D( Collider2D other) { 
		if (!isDockingInProgress && isDockEmpty && other.tag == "Player")
		{
			isDockingInProgress = true;
			player = other.gameObject.GetComponent<PlayerInfoContainer>();
			Dockable dockable = other.gameObject.GetComponent <Dockable>();
			
			// Čia visi veiksmai, kurie atliekami, kai laivas gali ir nori prisijungti
			if ( player.GetButtonDock() && !player.IsDockPause()) {
				isDockEmpty = false;
				Destroy( other.gameObject);
				GameObject newTurret = Instantiate(dockable.otherForm, transform.position, Quaternion.identity) as GameObject;
				newTurret.GetComponent<PlayerInfoContainer>().SetPlayerInfo( player.GetPlayerInfo());
				DockTurret(newTurret);
				Debug.Log( "You got docked boy");
			}
			else {
				isDockEmpty = true;
				Debug.Log("Ship does not want to dock");
			}
			isDockingInProgress = false;
		}
	}
	
	public GameObject GetTurret() {
		return turret;
	}
	
	public void DockTurret(GameObject newTurret) {
		isDockEmpty = false;
		turret = newTurret;
		player = turret.GetComponent<PlayerInfoContainer>();
		player.SetDockPause(0.5f);
		turret.transform.parent = transform;
	}
}

