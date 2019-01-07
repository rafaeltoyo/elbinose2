using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BasicStats{
	public float startHP;
	public float startMP;
	public int strenght;
	public int magic;
	public int agillity;
	public int baseDefense;
	public int baseAttack;
}

public abstract class CharacterBase : MonoBehaviour {
	
	//Atributos Basicos
	public int currentLevel;
	public BasicStats basicStats;
	
	
	
	

	protected void Start () {
		
	}

	protected void Update () {
		
	}
}
