using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public float aaDelay;
	public static bool inAtk;
	public float posx;
	public float posy;
	public Transform player;
	public PlayerBehaviour playerBase;
	public float atkController;
	public Animator anim;
	// Use this for initialization
	void Start () {
		posx = 0;
		posy = 0;
		player = GameObject.FindGameObjectWithTag("Player").transform;
		atkController = 0;
		aaDelay = 10; 
	}
	
	// Update is called once per frame
	void Update () {
		//Contador de Delay pro Auto Attack
		if (aaDelay < 10) 
						aaDelay += Time.deltaTime;
		// Pegar direçao do ataque
		if (!inAtk) {
						if (Input.GetKey (KeyCode.UpArrow)) {
								posy = 0.1f;
								if (Input.GetKey (KeyCode.RightArrow)) {
										posx = 0.1f;
								} else if (Input.GetKey (KeyCode.LeftArrow)) {
										posx = -0.1f;
								} else {
										posx = 0;
								}
						} else if (Input.GetKey (KeyCode.DownArrow)) {
								posy = -0.1f;
								if (Input.GetKey (KeyCode.RightArrow)) {
										posx = 0.1f;
								} else if (Input.GetKey (KeyCode.LeftArrow)) {
										posx = -0.1f;
								} else {
										posx = 0;
								}
						} else {
								if (Input.GetKey (KeyCode.RightArrow)) {
										posx = 0.1f;
										if (Input.GetKey (KeyCode.UpArrow)) {
												posy = 0.1f;
										} else if (Input.GetKey (KeyCode.DownArrow)) {
												posy = -0.1f;
										} else {
												posy = 0;
										}
								} else if (Input.GetKey (KeyCode.LeftArrow)) {
										posx = -0.1f;
										if (Input.GetKey (KeyCode.UpArrow)) {
												posy = 0.1f;
										} else if (Input.GetKey (KeyCode.DownArrow)) {
												posy = -0.1f;
										} else {
												posy = 0;
										}
								}
						}
				}
		//Atk speed
		if (PlayerPrefs.GetFloat (PlayerStatsController.CurrentSave () + "AtkSpeed") > 1f)
						PlayerPrefs.SetFloat (PlayerStatsController.CurrentSave () + "AtkSpeed", 1f);
		// Se tiver em Ataque ( apos apertar a tecla de ataque)
		if (inAtk) {
			if (atkController <= 0.4f){
				if (atkController > 0.15f && atkController < 0.4f){ // mover espada
				transform.position = (new Vector3 (posx, posy, 0)) + player.transform.position;
				}
				atkController += Time.deltaTime;
			} else { // Reset do ataque
				transform.position = player.transform.position;
				atkController = 0;
				PlayerPrefs.SetInt ("inAtk" , 0);
				anim.SetBool ("inATK", false);
				inAtk = false ;
			}
		}
		// Tecla de ataque ( Pegar o Ataque )
		if (aaDelay >= 1f - PlayerPrefs.GetFloat (PlayerStatsController.CurrentSave ()+"AtkSpeed") && !inAtk) {
						if (Input.GetKeyDown (KeyCode.Q)) {
								inAtk = true;
								PlayerPrefs.SetInt ("inAtk", 1);
								anim.SetBool ("inATK", true);
								aaDelay = 0;
						}
				}
	}
}
// PS: Resetador de inATK tambem contido no inimigo! / Aplicaçao de dano no inimigo com o tempo de imunidade dele
