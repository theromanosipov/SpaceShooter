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
		GUILayout.BeginArea(new Rect(Screen.width / 4, 0, Screen.width / 2, Screen.height));
		{
            GUILayout.Label("TBD, VERZYJA:0.0.0.0.0.0.0.1");
			if (GUILayout.Button("Play Game"))
			{
				Application.LoadLevel("Romo Level Experiment");
			}
			GUILayout.Label("Judėjimas \n Pulto kairė vairalazdė \n Klaviatūros krypties klavišai \n Klaviatūros IJKL mygtukai \n Klaviatūros WASD mygtukai \nPrisijungimas / atsijungimas \n Pulto B mygtukas \n Klaviatūros E mygtukas \n Klaviatūros O (numpad) mygtukas \nMelee / artima ataka \n Pulto A mygtukas \n Klaviatūros SPACE mygtukas \n Klaviatūros / (numpad) mygtukas \nSpecialioji ataka \n Pulto X mygtukas \n Klaviatūros Q mygtukas \n Klaviatūros U (numpad) mygtukas");
		}
		if (GUILayout.Button("Credits"))
		{
			currentPage = Page.Credits;
		}
		GUILayout.EndArea ();
		//GUI.Label (new Rect (Screen.width / 3, Screen.height * 9 / 10, Screen.width / 3, Screen.height / 10), "");
	}
	
	void CreditsPage(){
		GUI.Label(new Rect(Screen.width / 4,0 , Screen.width / 2, Screen.height / 2),
		          "TBD by FREE!");
        GUI.Label(new Rect(Screen.width / 4, Screen.height / 2, Screen.width / 2, Screen.height / 2),
                  "Justinas Červokas\nVilius Kaunas\nRoman Osipov\nKristupas Stumbrys");
		if(GUI.Button(new Rect(Screen.width / 4,  Screen.height * 3 / 8, Screen.width / 2, Screen.height / 8), "Back")){
			currentPage = Page.Main;
		}
	}	
}
