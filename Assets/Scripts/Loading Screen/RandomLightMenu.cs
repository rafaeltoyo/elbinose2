using UnityEngine;
using System.Collections;

public class RandomLightMenu : MonoBehaviour {
	public float posx;
	public float posy;
	public float introTime;
	public bool part1;
	public bool part2;
	// Use this for initialization
	void Start () {
		posx = 0;
		posy = -1.96f;
		introTime = 0;
		GetComponent<Light>().intensity = 0;
		part1 = true;
		part2 = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			if (Mensagem.fimIntro == true)
						Application.LoadLevel ("Menu");
			else
						Mensagem.fimIntro = true;
		}
		if (Mensagem.fimIntro == false) {
						if (introTime < 3 && part1) {
								introTime += Time.deltaTime;
								GetComponent<Light>().intensity = introTime;
						} else {
								part1 = false;
								part2 = true;
						}
						if (introTime > 0.8f && part2) {
								introTime -= Time.deltaTime * 3;
								GetComponent<Light>().intensity = introTime;
						} else if (!part1) {
								part2 = false;
								Mensagem.fimIntro = true;
						}
				} else {
						GetComponent<Light>().intensity = Random.Range (0.7f, 0.9f);
				}
	}
	void FixedUpdate () {
		posx = Random.Range (-0.1f, 0.1f);
		posy = -1.96f + Random.Range (-0.1f, 0.1f);
		transform.position = new Vector3 (posx, posy, -1);
	}
}
