using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum TypeCharacter{
	Beginner = 0,
	Warrior = 1,
	Mage = 2
}

public class PlayerBehaviour : CharacterBase {
	
	private TypeCharacter type;
	public bool newChar;
	public bool atributos;
	//Temporarios
	private int currentSTR;
	private int currentDEX;
	private int currentINT;
	private int currentVIT;
	private int currentAP;
	//Componentes
	public GUISkin HpBar;
	public GUISkin MpBar;
	public GUISkin XpBar;
	public GUISkin Text;
	public GUISkin Button;
	public GUISkin Quit;
	public Texture hud;
	public Rect windowRect;

	protected void Start(){
		base.Start();
		windowRect = new Rect(Screen.width /2 - 200, Screen.height /2 - 250, 400, 500);
		if (PlayerPrefs.GetInt (PlayerStatsController.CurrentSave () + "newChar") == 1)
				newChar = true;
		else if (PlayerPrefs.GetInt(PlayerStatsController.CurrentSave ()+"newChar") == 0)
				newChar = false;
		currentLevel = PlayerStatsController.GetCurrentLevel();
		type = PlayerStatsController.GetTypeCharacter();
		basicStats = PlayerStatsController.intance.GetBasicStats(type);
		if (newChar) {
			PlayerStatsController.SetTypeCharacter(TypeCharacter.Beginner);
			currentLevel = 1;
			PlayerPrefs.SetInt(PlayerStatsController.CurrentSave ()+"currentLevel",currentLevel);
			PlayerPrefs.SetInt(PlayerStatsController.CurrentSave ()+"currentXP",0);
			int xpBase = 100;
			PlayerPrefs.SetFloat (PlayerStatsController.CurrentSave ()+"maxXP",xpBase);
			PlayerPrefs.SetFloat (PlayerStatsController.CurrentSave ()+"maxHP",basicStats.startHP);
			PlayerPrefs.SetFloat (PlayerStatsController.CurrentSave ()+"maxMP",basicStats.startMP);
			PlayerPrefs.SetFloat (PlayerStatsController.CurrentSave ()+"currentHP",basicStats.startHP);
			PlayerPrefs.SetFloat (PlayerStatsController.CurrentSave ()+"currentMP",basicStats.startMP);
			PlayerPrefs.SetFloat (PlayerStatsController.CurrentSave ()+"baseHP",basicStats.startHP);
			PlayerPrefs.SetFloat (PlayerStatsController.CurrentSave ()+"baseMP",basicStats.startMP);
			PlayerPrefs.SetInt (PlayerStatsController.CurrentSave ()+"currentAP", 10);
			PlayerPrefs.SetInt(PlayerStatsController.CurrentSave ()+"newChar", 0);
			PlayerPrefs.SetInt (PlayerStatsController.CurrentSave () + "STR", 0);
			PlayerPrefs.SetInt (PlayerStatsController.CurrentSave () + "DEX", 0);
			PlayerPrefs.SetInt (PlayerStatsController.CurrentSave () + "INT", 0);
			PlayerPrefs.SetInt (PlayerStatsController.CurrentSave () + "VIT", 0);

			}
		atributos = false;
	}

	
	// Update is called once per frame
	protected void Update () {
			base.Update();
			PlayerPrefs.SetFloat (PlayerStatsController.CurrentSave () + "ATK",basicStats.baseAttack + basicStats.strenght/10 * PlayerPrefs.GetInt (PlayerStatsController.CurrentSave () + "STR"));
			PlayerPrefs.SetFloat (PlayerStatsController.CurrentSave () + "DEF",basicStats.baseDefense/10 + basicStats.baseDefense/10 * PlayerPrefs.GetInt (PlayerStatsController.CurrentSave () + "VIT"));
			PlayerPrefs.SetFloat (PlayerStatsController.CurrentSave () + "MATK",5 + basicStats.magic * PlayerPrefs.GetInt (PlayerStatsController.CurrentSave () + "INT")/10);
			PlayerPrefs.SetFloat (PlayerStatsController.CurrentSave () + "AtkSpeed", (basicStats.agillity/1250f) * PlayerPrefs.GetInt (PlayerStatsController.CurrentSave () + "DEX"));
	}

		// Barras da tela -------------------------------------------------------------------------------

	
		void OnGUI () {
		
			
		GUI.skin = Text;
		int LVL = PlayerPrefs.GetInt (PlayerStatsController.CurrentSave ()+"currentLevel");
		GUI.Box (new Rect(0, 3, 50 ,30), "LVL:"+ LVL.ToString("f0"));
		
		GUI.skin = Text;
		GUI.Box (new Rect(50, 3, 200 ,30), "HP:"+PlayerPrefs.GetFloat (PlayerStatsController.CurrentSave ()+"currentHP").ToString("f0") + "/" + PlayerPrefs.GetFloat (PlayerStatsController.CurrentSave ()+"maxHP").ToString("f0"));
		
		GUI.skin = HpBar;
		GUI.Box (new Rect(50, 3, 200 * (PlayerPrefs.GetFloat (PlayerStatsController.CurrentSave ()+"currentHP") / PlayerPrefs.GetFloat (PlayerStatsController.CurrentSave ()+"maxHP")) ,30), " ");
		
		GUI.skin = Text;
		GUI.Box (new Rect(50, 33, 200 ,20), "MP:"+PlayerPrefs.GetFloat (PlayerStatsController.CurrentSave ()+"currentMP").ToString("f0") + "/" + PlayerPrefs.GetFloat (PlayerStatsController.CurrentSave ()+"maxMP").ToString("f0"));
		
		GUI.skin = MpBar;
		GUI.Box (new Rect(50, 33, 200 * (PlayerPrefs.GetFloat (PlayerStatsController.CurrentSave ()+"currentMP") / PlayerPrefs.GetFloat (PlayerStatsController.CurrentSave ()+"maxMP")) ,20), " ");
		
		GUI.skin = Text;
		float xp = PlayerPrefs.GetFloat (PlayerStatsController.CurrentSave ()+"currentXP");
		float maxxp = PlayerPrefs.GetFloat (PlayerStatsController.CurrentSave ()+"maxXP");
		float tamanho;
		GUI.Box (new Rect(50, 53, 100 ,20), "XP:"+xp.ToString("f0") + "/" + maxxp.ToString("f0"));
		
		GUI.skin = XpBar;
		if (maxxp == 0) {
			tamanho = 100;
		} else {
			tamanho = 100*(xp / maxxp);
			if ( tamanho > 100 )
				tamanho = 100;
		}
		GUI.Box (new Rect(50, 53, tamanho,20), " ");
		GUI.skin = Text;
		GUI.Box (new Rect (Screen.width - Screen.width/3, Screen.height - 50, Screen.width/3, 50), PlayerPrefs.GetString (PlayerStatsController.CurrentSave ()+"nome"));

		GUI.Label (new Rect (0,0,Screen.width,Screen.height),hud);
		GUI.skin = Button;
		if (GUI.Button (new Rect (Screen.width - 100, 0, 100, 30), "Pause"))
						PauseGame.pause = !PauseGame.pause;
		if (GUI.Button (new Rect (Screen.width - 200, 0, 100, 30), "Attributes")) {
						currentSTR = 0;
						currentDEX = 0;
						currentINT = 0;
						currentVIT = 0;
						currentAP = PlayerPrefs.GetInt (PlayerStatsController.CurrentSave () + "currentAP");
						atributos = !atributos;
				}
		if (atributos)
						windowRect = GUI.Window (0, windowRect, Attributes, "Character Attributes");
	}
	void Attributes(int windowID) {
		//Tela de Atributos
		GUI.skin = Button;
		GUI.Box(new Rect(20, 50, 100, 30), "STR");
		GUI.Box(new Rect(20, 100, 100, 30), "DEX");
		GUI.Box(new Rect(20, 150, 100, 30), "INT");
		GUI.Box(new Rect(20, 200, 100, 30), "VIT");
		GUI.skin = Text;
		GUI.Box(new Rect(140, 50, 80, 30), PlayerPrefs.GetInt (PlayerStatsController.CurrentSave ()+"STR").ToString("f0"));
		GUI.Box(new Rect(140, 100, 80, 30), PlayerPrefs.GetInt (PlayerStatsController.CurrentSave ()+"DEX").ToString("f0"));
		GUI.Box(new Rect(140, 150, 80, 30), PlayerPrefs.GetInt (PlayerStatsController.CurrentSave ()+"INT").ToString("f0"));
		GUI.Box(new Rect(140, 200, 80, 30), PlayerPrefs.GetInt (PlayerStatsController.CurrentSave ()+"VIT").ToString("f0"));
		GUI.skin = Button;
		GUI.Box(new Rect(140, 250, 80, 30), "AP:");
		GUI.skin = Text;
		GUI.Box(new Rect(240, 50, 60, 30), currentSTR.ToString("f0"));
		GUI.Box(new Rect(240, 100, 60, 30), currentDEX.ToString("f0"));
		GUI.Box(new Rect(240, 150, 60, 30), currentINT.ToString("f0"));
		GUI.Box(new Rect(240, 200, 60, 30), currentVIT.ToString("f0"));
		GUI.Box(new Rect(240, 250, 60, 30), currentAP.ToString("f0"));
		GUI.skin = Button;
		if (GUI.Button (new Rect (320, 55, 30, 20), "<")) {
			if (currentSTR > 0) {
				currentAP = currentAP+1;
				currentSTR -= 1;
			}
		}
		if (	GUI.Button(new Rect(320, 105, 30, 20), "<")) {
			if (currentDEX > 0) {
				currentAP = currentAP+1;
				currentDEX -= 1;
			}
		}
		if (	GUI.Button(new Rect(320, 155, 30, 20), "<")) {
			if (currentINT > 0) {
				currentAP = currentAP+1;
				currentINT -= 1;
			}
		}
		if (	GUI.Button(new Rect(320, 205, 30, 20), "<")) {
			if (currentVIT > 0) {
				currentAP = currentAP+1;
				currentVIT -= 1;
			}
		}
		if (	GUI.Button(new Rect(350, 55, 30, 20), ">")) {
			if (currentAP > 0) {
				currentAP = currentAP-1;
				currentSTR +=1;
			}
		}
		if (	GUI.Button(new Rect(350, 105, 30, 20), ">")) {
			if (currentAP > 0) {
				currentAP = currentAP-1;
				currentDEX +=1;
			}
		}
		if (	GUI.Button(new Rect(350, 155, 30, 20), ">")) {
			if (currentAP > 0) {
				currentAP = currentAP-1;
				currentINT +=1;
			}
		}
		if (	GUI.Button(new Rect(350, 205, 30, 20), ">")) {
			if (currentAP > 0) {
				currentAP = currentAP-1;
				currentVIT +=1;
			}
		}
		if (GUI.Button (new Rect (320, 250, 60, 30), "SAVE")) {
			PlayerPrefs.SetInt(PlayerStatsController.CurrentSave () + "currentAP",currentAP);
			SaveAP ();
		}
		GUI.skin = Quit;
		if (	GUI.Button(new Rect(380, 0, 15, 15), "")) {
			atributos = false;
			}
		GUI.skin = Button;
		GUI.DragWindow();
	}
	
	public void SaveAP () {
		int str = PlayerPrefs.GetInt (PlayerStatsController.CurrentSave () + "STR");
		int dex = PlayerPrefs.GetInt (PlayerStatsController.CurrentSave () + "DEX");
		int inte = PlayerPrefs.GetInt (PlayerStatsController.CurrentSave () + "INT");
		int vit = PlayerPrefs.GetInt (PlayerStatsController.CurrentSave () + "VIT");
		float currentMaxHP = PlayerPrefs.GetFloat(PlayerStatsController.CurrentSave ()+"maxHP");
		float currentMaxMP = PlayerPrefs.GetFloat(PlayerStatsController.CurrentSave ()+"maxMP");
		PlayerPrefs.SetInt (PlayerStatsController.CurrentSave () + "STR", currentSTR + str);
		PlayerPrefs.SetInt (PlayerStatsController.CurrentSave () + "DEX", currentDEX + dex);
		PlayerPrefs.SetInt (PlayerStatsController.CurrentSave () + "INT", currentINT + inte);
		PlayerPrefs.SetInt (PlayerStatsController.CurrentSave () + "VIT", currentVIT + vit);
		PlayerPrefs.SetFloat (PlayerStatsController.CurrentSave () + "maxHP", currentMaxHP + (float)currentVIT * basicStats.startHP);
		PlayerPrefs.SetFloat (PlayerStatsController.CurrentSave () + "maxMP", currentMaxMP + (float)currentINT * basicStats.startMP);
		currentSTR = 0;
		currentDEX = 0;
		currentINT = 0;
		currentVIT = 0;
	}
}