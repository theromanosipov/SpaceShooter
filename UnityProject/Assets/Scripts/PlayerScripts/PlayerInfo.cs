using UnityEngine;
using System.Collections;

/// <summary>
/// Saugo informaciją apie konkretų žaidėją: kontrolerio numerį, surinktu taškus.
/// Leidžia gauti žaidėjo nuspaustus mygtukus ir gauti bei modifikuoti taškus.
/// </summary>
public class PlayerInfo {

	public PlayerInfo( int controllerNumber) {
		this.controllerNumber = controllerNumber;
        dockPause = Time.time;
	}

	public int controllerNumber;
	public long score = 0;
	public int hitPoints = 100;

    // Vykstant prisidokavimui ir atsidokavimaui dockPause įrašomas laikas, kada galima atlikti kitą tokią operaciją
    public float dockPause;
}
