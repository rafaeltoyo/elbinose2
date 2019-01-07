using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

	public static bool pause = false;		//Variavel booleana de gatilho, feita pra Pausar o jogo
	public GUISkin layout;
	public GUISkin button;
	public int option;
	public GameObject lvlcont;

	void Start () {
				pause = false;
		}
	void Update () {

				if (Input.GetKeyDown (KeyCode.Escape)) {
						if (pause == true) {
								pause = false;
						} else {
								pause = true;
								option = 1;
						}
				}
						if (pause == true) {
								Time.timeScale = 0;
								AudioListener.pause = true;
						} else if (pause == false){
								Time.timeScale = 1;
								AudioListener.pause = false;
						}
		}
	void OnGUI () {
			if (pause == true) {

			//Base
				GUI.skin = layout;
				int lar1 = Screen.width/2;
				int alt1 = Screen.height/2;
				int posx1 = Screen.width/2 - lar1/2;
				int posy1 = Screen.height/2 - alt1/2;
				GUI.Box ( new Rect ( posx1 ,posy1, lar1, alt1), "");
				GUI.Box ( new Rect ( posx1 ,posy1, lar1, Screen.height/20), "PAUSE");
			//Botoes
				GUI.skin = button;
				int lar2 = Screen.width/3;
				int alt2 = Screen.height/20;
				int posx2 = Screen.width/2 - lar2/2;
				int posy2 = Screen.height/20 * 7;
				if (GUI.Button ( new Rect ( posx2 ,posy2, lar2, alt2), "RESUME"))
					pause = false;
				if (GUI.Button ( new Rect ( posx2 ,posy2 + alt2 * 2, lar2, alt2), "HELP"))
					option = 2;
				if (GUI.Button ( new Rect ( posx2 ,posy2 + alt2 * 4, lar2, alt2), "RETURN MENU")) {
					Application.LoadLevel("Menu");
			}
			}
	}
}
