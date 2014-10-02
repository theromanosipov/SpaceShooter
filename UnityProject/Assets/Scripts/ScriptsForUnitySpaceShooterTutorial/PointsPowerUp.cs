using UnityEngine;
using System.Collections;

public class PointsPowerUp : GenericPowerUp {

  public int newPoints;
	
  protected override void ApplyPowerUp() {
    gameController.AddScore( newPoints);
  }
}
