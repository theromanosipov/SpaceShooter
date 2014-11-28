using UnityEngine;
using System.Collections;

public class RythmUtility : MonoBehaviour {

    public static float[] beatArray = new float[50] { 1.317f,1.896f,2.507f,3.119f,3.687f,4.299f,4.866f,5.463f,6.06f,6.657f,7.239f,7.821f,8.403f,8.985f,9.612f,10.179f,10.791f,11.37f,11.97f,12.55f,13.15f,13.73f,14.32f,14.925f,15.51f,16.112f,16.7f,17.28f,17.875f,18.468f,19.05f,19.647f,20.25f,20.841f,21.427f,22.022f,22.62f,23.2f,23.795f,24.38f,24.976f,25.577f,26.159f,26.752f,27.336f,27.937f,28.53f,29.112f,29.705f,30.289f };

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
}
