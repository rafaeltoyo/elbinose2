using UnityEngine;
using System.Collections;

public class InimigoControleBack : MonoBehaviour {

	public float retardo;
	public float maxSpeed = 2f;
	public Vector3 FimAlerta;
	public Vector3 diferenca;
	private Transform player;
	private Animator anim;
	private bool livre = true;
	public bool teste=false;
	// Use this for initialization
	void Start () {

	}
	void Awake (){
		player = GameObject.FindGameObjectWithTag("Player").transform;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay2D ( Collider2D alerta)
	{
		if (alerta.isTrigger && alerta.collider2D.tag == "Player") {
			diferenca = transform.position - player.position;
						anim.SetFloat ("Velocidade", 1);
				} 
	}
	void OnTriggerExit2D (Collider2D alerta)
	{
		if (alerta.isTrigger || alerta.collider2D.tag == "Player") {
		anim.SetFloat ("Velocidade", 0);
		diferenca = FimAlerta;
		}
	}
	void FixedUpdate () {
		if (diferenca.x < 0.2 && diferenca.x > -0.2 && livre) {
			
			//Lado 1 - UP / Lado 2 - DOWN / Lado 3 - RIGHT / Lado 4 - LEFT
			if (diferenca.y > 0.01) {
				transform.position += transform.up * -1 * maxSpeed * Time.deltaTime * retardo;
				anim.SetInteger ("Lado",1);
			} else
			if (diferenca.y < -0.01) {
				transform.position += transform.up * 1 * maxSpeed * Time.deltaTime * retardo;
				anim.SetInteger ("Lado",2);
			}
			if (diferenca.x < -0.01) {
				transform.position += transform.right * 1 * maxSpeed * Time.deltaTime * retardo;
			} else
			if (diferenca.x > 0.01) {
				transform.position += transform.right * -1 * maxSpeed * Time.deltaTime * retardo;
			} else {
				transform.position += transform.right * 0;
			}
		}  else if (livre){
			if (diferenca.y < -0.01) {
				transform.position += transform.up * 1 * maxSpeed * Time.deltaTime * retardo;
			} else
			if (diferenca.y > 0.01) {
				transform.position += transform.up * -1 * maxSpeed * Time.deltaTime * retardo;
			} else {
				transform.position += transform.up * 0;
			}
			if (diferenca.x < -0.01) {
				transform.position += transform.right * 1 * maxSpeed * Time.deltaTime * retardo;
				anim.SetInteger ("Lado",3);
			} else
			if (diferenca.x > 0.01) {
				transform.position += transform.right * -1 * maxSpeed * Time.deltaTime * retardo;
				anim.SetInteger ("Lado",4);
			}
		}
	}
	public float diferencay;
	public float diferencax;
	public bool perm=true;
	public bool primEx = false;
	public float direcao = 0;
	void OnCollisionEnter2D (Collision2D Obs) {
		perm = false;
		diferencax = diferenca.x;
		diferencay = diferenca.y;
		//if (Mathf.Abs (diferencax) > Mathf.Abs (diferencay)) {
		//ContactPoint2D
			if (diferencay<0) {
				if (diferencax<0) {
					direcao =1;
				} else if (diferencax>0) {
					direcao =2;
				}
			} else if (diferencay>0) {
				if (diferencax<0) {
					direcao =3;
				} else if (diferencax>0) {
					direcao =4;
				}
			}
		primEx = true;
		perm = true;
	}
	void OnCollisionStay2D (Collision2D Obs) {
		if (Obs.collider.tag == "Obstacle" && perm) {
			livre = false;

			if ( diferenca.y > 0.01 && diferenca.x < 0.01 ) {
				transform.position += transform.up * -1 * maxSpeed * Time.deltaTime * retardo;
				transform.position += transform.right * 1 * maxSpeed * Time.deltaTime * retardo;
				anim.SetInteger ("Lado",3);
			} else if ( diferenca.y > 0.01 && diferenca.x > 0.01) {
				transform.position += transform.up * -1 * maxSpeed * Time.deltaTime * retardo;
				transform.position += transform.right * -1 * maxSpeed * Time.deltaTime * retardo;
				anim.SetInteger ("Lado",4);
			} else if ( diferenca.y < 0.01 && diferenca.x < 0.01) {
				transform.position += transform.up * 1 * maxSpeed * Time.deltaTime * retardo;
				transform.position += transform.right * 1 * maxSpeed * Time.deltaTime * retardo;
				anim.SetInteger ("Lado",3);
			} else if ( diferenca.y < 0.01 && diferenca.x > 0.01) {
				transform.position += transform.up * 1 * maxSpeed * Time.deltaTime * retardo;
				transform.position += transform.right * -1 * maxSpeed * Time.deltaTime * retardo;
				anim.SetInteger ("Lado",4);
			}
		}
	}
	void OnCollisionExit2D (Collision2D Obs) {
			livre = true;
	}
	IEnumerator Delay (){
		yield return new WaitForSeconds(5f);
	}
}
