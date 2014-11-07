using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public enum Page{
		Main, Credits
	}
	private Page currentPage = Page.Main;
	
	void Start () {

	}
	
	void LateUpdate() {
		if (Input.GetKeyDown("escape")){
				currentPage = Page.Main;
		}
	}
	
	void OnGUI(){
		switch (currentPage){
		case Page.Main: MainPage(); break;
		case Page.Credits: CreditsPage(); break;
		}
	}
	
	void MainPage()
	{
		GUILayout.BeginArea(new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height));
		{
			if (GUILayout.Button("Play Game"))
			{
				Application.LoadLevel("Main");
			}
		}
		if (GUILayout.Button("Credits"))
		{
			currentPage = Page.Credits;
		}
		GUILayout.EndArea ();
		GUI.Label (new Rect (0, Screen.height * 9 / 10, Screen.width / 3, Screen.height / 10), "VERZYJA:0.0.0.0.0.0.0.1");
	}
	
	void CreditsPage(){
		GUI.Label(new Rect(0, Screen.height / 2, Screen.width, Screen.height / 2),
		          "Space Joint by Free");
		if(GUI.Button(new Rect(Screen.width / 2,  Screen.height * 3 / 8, Screen.width / 4, Screen.height / 8), "Back")){
			currentPage = Page.Main;
		}
	}	
}
