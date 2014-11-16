using UnityEngine;
using System.Collections;
/// <summary>
/// Klasė, kuri sukuria ir išsaugo PlayerInfo ir ateityje spawnins priešus (gal)
/// </summary>
public class x2D_GameController : MonoBehaviour
{
	//Visų žaidėjų PlayerInfo
	public int lives;
	public int playerCount;
	public PlayerInfo[] player;
	public GameObject[] shipsToSpawnAtStart;
	public GameObject meelePrefab;
		
	public virtual void Start ()
		{
		//Vos tik prasideda žaidimas inicializuojami 4 PlayerInfo
		player = new PlayerInfo[4];
		for (int i = 0; i < 4; i++) {
						player [i] = new PlayerInfo (i+1);
				}

		//Spawninami žaidėjų laivai
		for (int i=0; i<playerCount; i++) 
		{
			GameObject playerShip = Instantiate (meelePrefab, new Vector2 (-8+i*16/(playerCount-1), -8), Quaternion.identity) as GameObject;
			//				//Naujau sukurtam žaidėjo laivui duoda PlayerInfo, kad šis galėtų būt valdomas
			playerShip.GetComponent<PlayerInfoContainer> ().SetPlayerInfo (player [i]);
		}

		//for (int i = 0; i < shipsToSpawnAtStart.Length; i++) {
		//				GameObject playerShip = Instantiate (shipsToSpawnAtStart [i], new Vector2 (2 * i - 1, -8), Quaternion.identity) as GameObject;
		//				//Naujau sukurtam žaidėjo laivui duoda PlayerInfo, kad šis galėtų būt valdomas
		//				playerShip.GetComponent<PlayerInfoContainer> ().SetPlayerInfo (player [i]);
		//		}
		}
	void playerDied(PlayerInfo deadPlayer)
	{
		if (lives > 0) 
		{
			lives--;
			GameObject playerShip = Instantiate (meelePrefab, new Vector2 (0, -8), Quaternion.identity) as GameObject;
			playerShip.GetComponent<PlayerInfoContainer> ().SetPlayerInfo (deadPlayer);
		}
	}
}

