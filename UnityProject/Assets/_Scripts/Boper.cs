using UnityEngine;
using System.Collections;

public class Boper : MonoBehaviour {

	public AnimationCurve bopCurve;

    private Vector3 startingScale;

    void Start() {
        startingScale = transform.localScale;
    }

    void Update() {
        float scale = bopCurve.Evaluate( RythmUtility.getBeatProgress());
        transform.localScale = startingScale * scale;
	}
}
