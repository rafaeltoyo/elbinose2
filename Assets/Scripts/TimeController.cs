using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour {
	private float seconds;
	private float minutes;
	private float hours;
	private float cont;
	// ARRUMAR AINDA !!!
	// Ideias : Usa para controlar spawn de boss e itens
	// Contar tempo por save e Apenas quando estiver em jogo ( clica start começa contar e qnd voltar para o menu ou entrar no jogo cancelar) <- Implementar
	void Start () {
						seconds = 0;
						minutes = 0;
						hours = 0;
						cont = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		cont += Time.deltaTime;
		if (cont >= 1) {
						cont -= 1;
						seconds += 1;
						print (hours + " : " + minutes + " : " + seconds); // Reloginho :)
				}
		if (seconds >= 60) {
						seconds -= 60;
						minutes += 1;
				}
		if (minutes >= 60) {
						minutes -= 60;
						hours += 1;
				}
	}
}
