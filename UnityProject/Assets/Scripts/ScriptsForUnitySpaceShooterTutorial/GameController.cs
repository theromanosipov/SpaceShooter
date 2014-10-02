using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
  public GameObject hazard;
  public GameObject player;
  public Vector3 spawnValues;
  public int hazardCount;
  public float spawnWait;
  public float startWait;
  public float waveWait;
  public float respawnWait;
  
  public GameObject[] PowerUps;
	
  public GUIText scoreText;
  public GUIText restartText;
  public GUIText gameOverText;
  public GUIText livesText;
  
  private bool isGameOver;
  private bool isRestart;
  private bool isPlayerDead;
  private int score;
  
  public int lives;

  void Start() {
    isGameOver = isRestart = isPlayerDead = false;
	restartText.text = gameOverText.text = scoreText.text = "";
    StartCoroutine( SpawnWaves());
    score = 0;
    UpdateScore();
    UpdateLives();
  }
  
  void Update() {
    if( isRestart)
      if( Input.GetKeyDown( KeyCode.R))
		Application.LoadLevel (Application.loadedLevel);
  }
      
  
  IEnumerator SpawnWaves() {
	yield return new WaitForSeconds( startWait);
	while( true) {
      for( int i = 0; i < hazardCount; i++) {
		Instantiate( hazard, newSpawnPosition(), Quaternion.identity);
	    yield return new WaitForSeconds( spawnWait);
	  }
	  int whichPowerUp = Random.Range( 0, PowerUps.Length);
	  Instantiate( PowerUps[whichPowerUp], newSpawnPosition(), Quaternion.identity);
	  yield return new WaitForSeconds( waveWait);
	  if( isGameOver) {
		restartText.text = "Press 'R' to restart";
		isRestart = true;
		break;
      }
      if( isPlayerDead) {
		yield return new WaitForSeconds( respawnWait);
		Instantiate( player, new Vector3( 0, 0, 0), Quaternion.identity);
		isPlayerDead = false;
	  }
	}
  }
  
  public void AddScore( int newScore) {
    score += newScore;
    UpdateScore();
  }
  
  public void AddLives( int newLives) {
    lives += newLives;
    UpdateLives();
  }
  
  void UpdateScore() {
    scoreText.text = "Score: " + score + "00000";
  }
  
  void UpdateLives() {
    livesText.text = "Lives: " + lives;
  }
  
  public void GameOver() {
	if( !PlayerPrefs.HasKey( "bestScore"))
	  PlayerPrefs.SetInt( "bestScore", 0);
	int bestScore = PlayerPrefs.GetInt( "bestScore");
	Debug.Log ("BS " + bestScore);
	Debug.Log ("S " + score);
	if( score > bestScore) {
	  PlayerPrefs.SetInt( "bestScore", score);
	  PlayerPrefs.Save();
	  gameOverText.text = "Game Over\nNEW BEST SCORE!\n" + score + "00000";
	}
	else {
			gameOverText.text = "Game Over\nBest Score: " + bestScore + "00000\nYour Score: " + score + "00000"; 
	}	  
	isGameOver = true;
  }
  
  public void LoseLife() {
    isPlayerDead = true;
    lives--;
	UpdateLives();
    if( lives <= 0)
      GameOver();
  }
  
  private Vector3 newSpawnPosition() {
    return new Vector3( Random.Range( -spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
  }
}



























