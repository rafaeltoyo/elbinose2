using UnityEngine;
using System.Collections;

public class Mensagem : MonoBehaviour {
	public GUISkin text;
	public static bool fimIntro;
	public float cont;
	// Use this for initialization
	void Start () {
		fimIntro = false;
		cont = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (fimIntro) {
						cont += Time.deltaTime;
				}
		if (cont >= 0.65f)
						cont = 0;
	}
	void OnGUI () {
		GUIStyle myStyle = new GUIStyle();
		myStyle.fontSize = 10;
		myStyle.normal.textColor = Color.white;
		myStyle.wordWrap = true;
		myStyle.alignment = TextAnchor.UpperCenter;
		GUI.Label (new Rect (Screen.width - Screen.width / 30, Screen.height - Screen.height / 30 , Screen.width /30, Screen.height / 30), "V 1.0",myStyle);
		myStyle.fontSize = 30;

		if (fimIntro) {
			if (cont > 0.05f && cont <= 0.25f) {
				myStyle.normal.textColor = Color.gray;
				GUI.Label (new Rect (Screen.width/2 - 250, Screen.height - Screen.height/15 , 500, 50), "press ENTER",myStyle);
			}
			if (cont > 0.25f && cont <= 0.45f) {
				myStyle.normal.textColor = Color.white;
				GUI.Label (new Rect (Screen.width/2 - 250, Screen.height - Screen.height/15 , 500, 50), "press ENTER",myStyle);
			}
			if (cont > 0.45f) {
				myStyle.normal.textColor = Color.gray;
				GUI.Label (new Rect (Screen.width/2 - 250, Screen.height - Screen.height/15 , 500, 50), "press ENTER",myStyle);
			}
		}
	}
}