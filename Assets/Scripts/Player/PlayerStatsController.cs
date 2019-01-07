using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//fonte !! http://www.1001freefonts.com/homespun.font
[System.Serializable]
public class BasicInfoChar {
	public BasicStats baseInfo;
	public TypeCharacter typeChar;
}

public class PlayerStatsController : MonoBehaviour {
	
	public static PlayerStatsController intance;

	//Dados de Player
	public int maxLVL = 100;
	public int xpMultiply = 1;
	public float xpFirstLevel = 100;
	public float difficultFactor = 10f;
	public List<BasicInfoChar> baseInfoChars;

	public string currentSave;

	
	void Start () {
		intance = this;
		DontDestroyOnLoad(gameObject);
		
		
	}
	void Update () {

		if(Input.GetKeyDown(KeyCode.R))
			PlayerPrefs.DeleteAll();
		currentSave = PlayerStatsController.GetSave();

	}

	// Funçoes aqui para baixo ------------------------------------------------------------
	// LVL e XP
	public static void AddXp(float xpAdd){
		if (GetCurrentLevel () < PlayerStatsController.intance.maxLVL) {
						float newXp = GetCurrentXp () + xpAdd * PlayerStatsController.intance.xpMultiply;
						while (newXp >= GetNextXp()) {
								newXp -= GetNextXp ();
								AddLevel ();
						}
						PlayerPrefs.SetFloat(CurrentSave ()+"currentXP", newXp);
				}else {
						PlayerPrefs.SetFloat(CurrentSave ()+"currentXP", 0);
						PlayerPrefs.SetFloat (CurrentSave ()+"maxXP", 0);
				}
	}
	
	public static float GetCurrentXp(){
		return PlayerPrefs.GetFloat(CurrentSave ()+"currentXP");
	}
	
	public static int GetCurrentLevel(){
		return PlayerPrefs.GetInt(CurrentSave ()+"currentLevel");
	}
	
	public static void AddLevel(){
		int newLevel = GetCurrentLevel()+1;
		int newAP = PlayerPrefs.GetInt (CurrentSave ()+"currentAP")+5;
		PlayerPrefs.SetInt(CurrentSave ()+"currentLevel", newLevel);
		float newxpmax  = PlayerPrefs.GetFloat(CurrentSave ()+"maxXP")+ GetCurrentLevel()*PlayerStatsController.intance.difficultFactor;
		PlayerPrefs.SetFloat (CurrentSave ()+"maxXP", newxpmax);
		PlayerPrefs.SetInt (CurrentSave ()+"currentAP", newAP);
		UpdateHPMP ();
	}
	
	public static float GetNextXp(){
		return PlayerPrefs.GetFloat(CurrentSave ()+"maxXP");
	}

	//HP e MP
	public static void UpdateHPMP () {
		int currentLVL = PlayerPrefs.GetInt (CurrentSave ()+"currentLevel");
		float maxHP = PlayerPrefs.GetFloat (CurrentSave ()+"maxHP");
		float maxMP = PlayerPrefs.GetFloat (CurrentSave ()+"maxMP");
		PlayerPrefs.SetFloat (CurrentSave ()+"maxHP", maxHP + GetHPBASE());
		PlayerPrefs.SetFloat (CurrentSave ()+"maxMP", maxMP + GetMPBASE());
		PlayerPrefs.SetFloat (CurrentSave ()+"currentHP", PlayerPrefs.GetFloat (CurrentSave ()+"maxHP"));
		PlayerPrefs.SetFloat (CurrentSave ()+"currentMP", PlayerPrefs.GetFloat (CurrentSave ()+"maxMP"));
	}
	public static float GetHPBASE () {
		return PlayerPrefs.GetFloat (PlayerStatsController.CurrentSave () + "baseHP");
		}
	public static float GetMPBASE () {
		return PlayerPrefs.GetFloat (PlayerStatsController.CurrentSave () + "baseMP");
	}
	public static void TakeDamage (float Dmg) {
		float damage = Dmg - PlayerPrefs.GetFloat (CurrentSave ()+"DEF");
		if (damage < 1)
						damage = 1;
		float currentHP = PlayerPrefs.GetFloat (CurrentSave ()+"currentHP");
		PlayerPrefs.SetFloat (CurrentSave ()+"currentHP", currentHP - damage);
		if (PlayerPrefs.GetFloat (CurrentSave () + "currentHP") <= 0)
						PlayerPrefs.SetFloat (CurrentSave () + "currentHP", 0);
	}
	public static void UseMana (float Mana) {		
		float currentMP = PlayerPrefs.GetFloat (CurrentSave ()+"currentMP");
		PlayerPrefs.SetFloat (CurrentSave ()+"currentMP", currentMP - Mana);
	}
	
	// Tipo do Char
	public static TypeCharacter GetTypeCharacter(){
		
		int typeId = PlayerPrefs.GetInt(CurrentSave ()+"TypeCharacter");
		
		if(typeId == 0)
			return TypeCharacter.Beginner;
		else if(typeId == 1)
			return TypeCharacter.Warrior;
		else if(typeId == 2)
			return TypeCharacter.Mage;
		
		return TypeCharacter.Beginner;
	}
	
	public static void SetTypeCharacter(TypeCharacter newType){
		PlayerPrefs.SetInt(CurrentSave ()+"TypeCharacter", (int)newType);
	}
	
	public BasicStats GetBasicStats(TypeCharacter type){
		foreach(BasicInfoChar info in baseInfoChars){
			if(info.typeChar == type)
				return info.baseInfo;
		}
		
		return baseInfoChars[0].baseInfo;
	}
	// Atributos
	public static int GetAP () {
		return PlayerPrefs.GetInt (PlayerStatsController.CurrentSave () + "currentAP");
	}
	
	//Save e Loading
	public static string CurrentSave () {
		return PlayerStatsController.intance.currentSave;
	}
	public static string GetSave () {
		if (PlayerPrefs.GetInt ("currentSave") == 1)
			return "Personagem1";
		else if (PlayerPrefs.GetInt ("currentSave") == 2)
			return "Personagem2";
		else if (PlayerPrefs.GetInt ("currentSave") == 3)
			return "Personagem3";
		return "Personagem1";
	}
	

}