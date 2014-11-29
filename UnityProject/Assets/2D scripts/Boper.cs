using UnityEngine;
using System.Collections;

public class Boper : MonoBehaviour {

	public AnimationCurve bopCurve;

    void Update() {
        transform.localScale = new Vector3(1, bopCurve.Evaluate( RythmUtility.getBeatProgress()), 1);
	}
}
