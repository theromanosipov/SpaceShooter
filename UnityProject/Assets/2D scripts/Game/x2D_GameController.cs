using UnityEngine;
using System.Collections;

/// <summary>
/// Konteineris, kur yra vieno spawninamo laivo informacija. 
/// Galima pridėti daugiau kintamųjų, pvz pozicija, spalva ir tt.
/// </summary>
[System.Serializable]
public class SpawningOptions
{
    public GameObject shipGameObject;
    public int playerNumber;
}

/// <summary>
/// Klasė, kuri spawnina žaidėjus
/// </summary>
public class x2D_GameController : MonoBehaviour
{
	public int lives;
	private PlayerInfo[] player;
    public SpawningOptions[] shipsToSpawnAtStart;
	public GameObject respawnPrefab;
		
	public virtual void Start ()
	{
        //Vos tik prasideda žaidimas inicializuojami PlayerInfo, pagal shipsToSpawnAtStart.Length
        player = new PlayerInfo[shipsToSpawnAtStart.Length];
        for (int i = 0; i < shipsToSpawnAtStart.Length; i++)
        {
            player[i] = new PlayerInfo(shipsToSpawnAtStart[i].playerNumber);
        }

        //Spawninami laivai
	    for (int i = 0; i < shipsToSpawnAtStart.Length; i++) {
	    	GameObject playerShip = Instantiate (shipsToSpawnAtStart [i].shipGameObject, new Vector2 (2 * i - 1, -8), Quaternion.identity) as GameObject;
	    	//Naujai spawnintam žaidėjo laivui duoda PlayerInfo, kad šis galėtų būti valdomas
	    	playerShip.GetComponent<PlayerInfoContainer> ().SetPlayerInfo (player [i]);
	    }
	}

    // Respawninamas sunaikintas laivas
	void playerDied(PlayerInfo deadPlayer)
	{
		if (lives > 0) 
		{
			lives--;
            GameObject playerShip = Instantiate(respawnPrefab, new Vector2(0, -8), Quaternion.identity) as GameObject;
			playerShip.GetComponent<PlayerInfoContainer> ().SetPlayerInfo (deadPlayer);
		}
	}
}

