using UnityEngine;
using System.Collections;

public class LifeUpPowerUp : GenericPowerUp {

  public int newLives;
  
  protected override void ApplyPowerUp() {
    gameController.AddLives( newLives);
  }
}
