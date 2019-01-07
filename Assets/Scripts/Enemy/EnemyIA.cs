using UnityEngine;
using System.Collections;

public class EnemyIA : MonoBehaviour {

	public float retardo;
	public float maxSpeed;
	public Vector3 FimAlerta;
	public Vector3 diferenca;
	private Transform player;
	private Animator anim;
	private bool livre;
	public bool passiva;
	public float delayPerMove;
	// Use this for initialization
	void Start () {
		maxSpeed = 2f;
		delayPerMove = 0;
		livre = true;
		passiva = true;
		player = GameObject.FindGameObjectWithTag("Player").transform;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	}
	void FixedUpdate () { 
		if (delayPerMove < 5) // Reset
			delayPerMove += Time.deltaTime;

		
		if (passiva && delayPerMove > 1 && delayPerMove < 1.1f) {
			retardo = 0.2f;
			diferenca = new Vector3 (Random.Range (-3, 3), Random.Range (-3, 3), 0);
			anim.SetFloat ("Velocidade", 1);
		}
		if (passiva && delayPerMove > 2) {
			diferenca = new Vector3 (0,0,0);
			retardo = 0.3f;
			delayPerMove = 0;
			anim.SetFloat ("Velocidade", 0);
		}
		// Base de movimentaçao baseado nas coordenadas passados acima.
		if (diferenca.x < 0.2 && diferenca.x > -0.2 && livre) {
			
			//Lado 1 - UP / Lado 2 - DOWN / Lado 3 - RIGHT / Lado 4 - LEFT
			if (diferenca.y > 0.01) {
				rigidbody2D.AddForce(new Vector3(0,-1,0) * maxSpeed * Time.deltaTime * retardo);
				anim.SetInteger ("Lado",1);
			} else
			if (diferenca.y < -0.01) {
				rigidbody2D.AddForce(new Vector3(0,1,0) * maxSpeed * Time.deltaTime * retardo);
				anim.SetInteger ("Lado",2);
			}
			if (diferenca.x < -0.01) {
				rigidbody2D.AddForce(new Vector3(1,0,0) * maxSpeed * Time.deltaTime * retardo);
			} else
			if (diferenca.x > 0.01) {
				rigidbody2D.AddForce(new Vector3(-1,0,0) * maxSpeed * Time.deltaTime * retardo);
			} else {
				transform.position += transform.right * 0;
			}
		}  else if (livre){
			if (diferenca.y < -0.01) {
				rigidbody2D.AddForce(new Vector3(0,1,0) * maxSpeed * Time.deltaTime * retardo);
			} else
			if (diferenca.y > 0.01) {
				rigidbody2D.AddForce(new Vector3(0,-1,0) * maxSpeed * Time.deltaTime * retardo);
			} else {
				transform.position += transform.up * 0;
			}
			if (diferenca.x < -0.01) {
				rigidbody2D.AddForce(new Vector3(1,0,0) * maxSpeed * Time.deltaTime * retardo);
				anim.SetInteger ("Lado",3);
			} else
			if (diferenca.x > 0.01) {
				rigidbody2D.AddForce(new Vector3(-1,0,0) * maxSpeed * Time.deltaTime * retardo);
				anim.SetInteger ("Lado",4);
			}
		}
	}
	void OnTriggerStay2D ( Collider2D alerta)
	{
		if (alerta.collider2D.tag == "Player") {
			anim.SetFloat ("Velocidade", 1);
			passiva = false;
			retardo = 0.3f;
			diferenca = transform.position - player.position;
		} 
	}
	void OnTriggerExit2D (Collider2D alerta)
	{
		if (alerta.collider2D.tag == "Player") {
			anim.SetFloat ("Velocidade", 0);
			diferenca = FimAlerta;
			passiva = true;
		}
	}
}
