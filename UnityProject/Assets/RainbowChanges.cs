using UnityEngine;
using System.Collections;

public class RainbowChanges : MonoBehaviour {

    public int duration;

    private int samples;
    private Color[] rainbow = RythmUtility.getRainbow();

    void Start() {
        samples = duration * rainbow.Length;
    }

	void Update () {
        int currentSample = RythmUtility.getCurrentBeat() % samples;
        int previousColor = currentSample / duration;
        int nextColor = (previousColor + 1) % rainbow.Length;
        float lerpValue = (currentSample % duration) * (1f / (float)duration) + (float)RythmUtility.getBeatProgress() / (float)duration;
        Debug.Log((float)RythmUtility.getCurrentBeat() / (float)duration);
        renderer.material.color = Color.Lerp(rainbow[previousColor], rainbow[nextColor], lerpValue);
	}
}
