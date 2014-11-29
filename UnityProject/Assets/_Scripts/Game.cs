using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	
	public static Game control;
	
	void Awake(){
		if(control == null){
			DontDestroyOnLoad(gameObject);
			control = this;
		}
		else if(control != this){
			Destroy(gameObject);
		}
	}
}