using UnityEngine;
using System.Collections;

public class PlayerControllers : MonoBehaviour {
		
	public float maxSpeed;
	private Animator anim;
	public bool ocup;

	void Awake(){
		anim = GetComponent<Animator> ();
	}

	void Update() {
		if(Input.GetKey(KeyCode.A))
			PlayerStatsController.AddXp (10000);
		}
	void FixedUpdate () {
				
				if (!PlayerAttack.inAtk) { // Pausar movimento quando estiver em ataque
						if (Input.GetKey (KeyCode.UpArrow)) {
								rigidbody2D.AddForce (new Vector3 (0, 1, 0) * maxSpeed * Time.deltaTime);
								float w = 0; 
								float h = 1;
								anim.SetFloat ("VelocidadeH", w);
								anim.SetFloat ("VelocidadeV", h);
								if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
										rigidbody2D.AddForce (new Vector3 (0, -1, 0) * maxSpeed * Time.deltaTime);
										anim.SetFloat ("VelocidadeH", 0);
										anim.SetFloat ("VelocidadeV", 0);
								}
								if (Input.GetKey (KeyCode.RightArrow)) {
										rigidbody2D.AddForce (new Vector3 (1, 0, 0) * maxSpeed * Time.deltaTime);
								}
								if (Input.GetKey (KeyCode.LeftArrow)) {
										rigidbody2D.AddForce (new Vector3 (-1, 0, 0) * maxSpeed * Time.deltaTime);
								} 
						} else if (Input.GetKey (KeyCode.DownArrow)) {
								rigidbody2D.AddForce (new Vector3 (0, -1, 0) * maxSpeed * Time.deltaTime);
								float w = 0; 
								float h = -1;
								anim.SetFloat ("VelocidadeH", w);
								anim.SetFloat ("VelocidadeV", h);
								if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
										rigidbody2D.AddForce (new Vector3 (1, 0, 0) * maxSpeed * Time.deltaTime);	
								}
								if (Input.GetKey (KeyCode.LeftArrow)) {
										rigidbody2D.AddForce (new Vector3 (-1, 0, 0) * maxSpeed * Time.deltaTime);
								} 
						} else if (Input.GetKey (KeyCode.RightArrow)) {
								rigidbody2D.AddForce (new Vector3 (1, 0, 0) * maxSpeed * Time.deltaTime);
								float w = 1; 
								float h = 0;
								anim.SetFloat ("VelocidadeH", w);
								anim.SetFloat ("VelocidadeV", h);
								if (Input.GetKey (KeyCode.LeftArrow)) {
										rigidbody2D.AddForce (new Vector3 (-1, 0, 0) * maxSpeed * Time.deltaTime);
										anim.SetFloat ("VelocidadeH", 0);
										anim.SetFloat ("VelocidadeV", 0);
								} 
						} else if (Input.GetKey (KeyCode.LeftArrow)) {
								rigidbody2D.AddForce (new Vector3 (-1, 0, 0) * maxSpeed * Time.deltaTime);
								float w = -1; 
								float h = 0;
								anim.SetFloat ("VelocidadeH", w);
								anim.SetFloat ("VelocidadeV", h);
						} else {
								anim.SetFloat ("VelocidadeH", 0);
								anim.SetFloat ("VelocidadeV", 0);
						}
				}
	}
}