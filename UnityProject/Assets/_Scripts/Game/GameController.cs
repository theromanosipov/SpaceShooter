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
public class GameController : MonoBehaviour
{
	public int lives;
	private PlayerInfo[] player;
    public SpawningOptions[] shipsToSpawnAtStart;
	public GameObject respawnPrefab;
    public Boundary2 boundary;
		
	public virtual void Start ()
	{
        // Vos tik prasideda žaidimas inicializuojami PlayerInfo, pagal shipsToSpawnAtStart.Length
        player = new PlayerInfo[shipsToSpawnAtStart.Length];
        for (int i = 0; i < shipsToSpawnAtStart.Length; i++)
        {
            player[i] = new PlayerInfo(shipsToSpawnAtStart[i].playerNumber);
        }

        // Spawninami laivai
	    for (int i = 0; i < shipsToSpawnAtStart.Length; i++) 
			SpawnPlayerShip (player [i], shipsToSpawnAtStart [i].shipGameObject, new Vector2 (-8 + i * 16 / (shipsToSpawnAtStart.Length), boundary.yMin*5/6));
	}

    // Respawninamas sunaikintas laivas
	void playerDied(PlayerInfo deadPlayer)
	{
		if (lives > 0) 
		{
			lives--;
			SpawnPlayerShip(deadPlayer, respawnPrefab, new Vector2(0, boundary.yMin*5/6));
		}
	}

	void SpawnPlayerShip(PlayerInfo playerInfo, GameObject prefab, Vector2 location)
	{
		GameObject playerShip = Instantiate(prefab, location, Quaternion.identity) as GameObject;
		playerShip.GetComponent<PlayerInfoContainer>().SetPlayerInfo(playerInfo);    // Žaidėjo laivui duoda PlayerInfo, kad šis galėtų būti valdomas
		playerShip.GetComponent<PlayerController>().boundary = boundary;        // Nustato lygio ribas
	}
}

