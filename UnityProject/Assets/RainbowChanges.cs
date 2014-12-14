using UnityEngine;
using System.Collections;

public class RainbowChanges : MonoBehaviour {

    public int duration;

    private int samples;
    public Color[] rainbow = RythmUtility.getRainbow();

    public virtual void Start() {
        samples = duration * rainbow.Length;
    }

	void Update () {
        int currentSample = RythmUtility.getCurrentBeat() % samples;
        int previousColor = currentSample / duration;
        int nextColor = (previousColor + 1) % rainbow.Length;
        float lerpValue = (currentSample % duration) * (1f / (float)duration) + (float)RythmUtility.getBeatProgress() / (float)duration;
        assignColor (Color.Lerp(rainbow[previousColor], rainbow[nextColor], lerpValue));
	}

    public virtual void assignColor(Color newColor) {
        renderer.material.color = newColor;
    }
}
