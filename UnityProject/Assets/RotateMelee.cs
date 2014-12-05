using UnityEngine;
using System.Collections;

public class RotateMelee : GenericPlayerController {

    public float rotationRate;
    public float pauseAfterRotation;
    private bool isRotating = false;
	
	// Update is called once per frame
    public override void Update() {
        base.Update();

        if (player.GetButtonDock())
            StartCoroutine(Rotate(-45));
        else if (player.GetButtonPowerup())
            StartCoroutine(Rotate(45));
	}

    IEnumerator Rotate( float angle) {
        if (isRotating)
            yield break;
        isRotating = true;

        Debug.Log("Started rotation");

        float t = 0;
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = transform.rotation * Quaternion.Euler(0, 0, angle);

        while (t < 1 + pauseAfterRotation) {
            t += rotationRate * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
            yield return 0;
        }
        isRotating = false;

        Debug.Log("Ended rotation");
    }
}
