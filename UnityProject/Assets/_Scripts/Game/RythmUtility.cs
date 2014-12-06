using UnityEngine;
using System.Collections;

public class RythmUtility : MonoBehaviour {

    private static float[] beatArray = new float[102] { 1.317f,1.896f,2.507f,3.119f,3.687f,4.299f,4.866f,5.463f,6.06f,6.657f,7.239f,7.821f,8.403f,8.985f,9.612f,10.179f,10.791f,11.37f,11.97f,12.55f,13.15f,13.73f,14.32f,14.925f,15.51f,16.112f,16.7f,17.28f,17.875f,18.468f,19.05f,19.647f,20.25f,20.841f,21.427f,22.022f,22.62f,23.2f,23.795f,24.38f,24.976f,25.577f,26.159f,26.752f,27.336f,27.937f,28.53f,29.112f,29.705f,30.289f,30.869f,31.479f,32.057f,32.654f,33.237f,33.828f,35.029f,35.612f,36.206f,36.797f,37.391f,37.987f,38.571f,39.167f,39.75f,40.337f,40.928f,41.529f,42.118f,42.701f,43.287f,43.886f,44.483f,45.069f,45.663f,46.262f,46.848f,47.428f,48.017f,48.603f,49.197f,49.78f,50.374f,50.965f,51.564f,52.158f,52.749f,53.348f,53.94f,54.527f,55.119f,55.715f,56.304f,56.897f,57.484f,58.077f,58.668f,59.253f,59.846f,60.44f,61.038f,61.627f };
    private static float beatProgress;
    private static int currentBeat = 0;

    private static Color[] rainbow = new Color[6] { new Color32(255,0,0,255), 
                                                    new Color32(255,142,0,255), 
                                                    new Color32(255,237,0,255), 
                                                    new Color32(0,255,23,255), 
                                                    new Color32(0,107,255,255), 
                                                    new Color32(178,0,255,255)
    };

    public static float[] getBeatArray() {
        return beatArray;
    }

    public static float getBeatNumber(float time) {
        int i = (int) ((time - 1.317f) * 0.588);
        if (beatArray[i] > time) {
            i--;
        }
        else if (beatArray[i + 1] < time) {
            i++;
        }
        return (time - beatArray[i]) / (beatArray[i + 1] - beatArray[i]);
    }

    void Update() {
        float mainSongTime = (float)audio.timeSamples / (float)audio.clip.frequency;

        int i = (int) ((mainSongTime - 1.317f) / 0.588);
        if (beatArray[i] > mainSongTime) {
            i--;
        }
        else if (beatArray[i + 1] < mainSongTime) {
            i++;
        }
        currentBeat = i;
        beatProgress = (mainSongTime - beatArray[i]) / (beatArray[i + 1] - beatArray[i]);
    }

    public static float getBeatProgress() {
        return beatProgress;
    }

    public static int getCurrentBeat() {
        return currentBeat;
    }

    public static Color[] getRainbow() {
        return rainbow;
    }

}
