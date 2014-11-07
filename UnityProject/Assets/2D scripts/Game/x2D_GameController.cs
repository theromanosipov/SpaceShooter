using UnityEngine;
using System.Collections;
/// <summary>
/// Klasė, kuri sukuria ir išsaugo PlayerInfo ir ateityje spawnins priešus (gal)
/// </summary>
public class x2D_GameController : MonoBehaviour
{
	//Visų žaidėjų PlayerInfo
	public PlayerInfo[] player;
	public GameObject[] shipsToSpawnAtStart;
		
	public virtual void Start ()
		{
		//Vos tik prasideda žaidimas inicializuojami 4 PlayerInfo
		player = new PlayerInfo[4];
		for (int i = 0; i < 4; i++) {
						player [i] = new PlayerInfo (i+1);
				}

		//Spawninami žaidėjų laivai
		for (int i = 0; i < shipsToSpawnAtStart.Length; i++) {
						GameObject playerShip = Instantiate (shipsToSpawnAtStart [i], new Vector2 (2 * i - 1, -8), Quaternion.identity) as GameObject;
						//Naujau sukurtam žaidėjo laivui duoda PlayerInfo, kad šis galėtų būt valdomas
						playerShip.GetComponent<PlayerInfoContainer> ().SetPlayerInfo (player [i]);
				}
		}
}

