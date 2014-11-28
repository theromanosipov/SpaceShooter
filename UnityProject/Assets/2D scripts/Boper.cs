using UnityEngine;
using System.Collections;

public class Boper : MonoBehaviour {

	public AnimationCurve bopCurve;

    void Update() {
        float currentBeatPassed = RythmUtility.getBeatNumber((float)audio.timeSamples / (float)audio.clip.frequency);
        transform.localScale = new Vector3(1, bopCurve.Evaluate(currentBeatPassed), 1);
	}
}
