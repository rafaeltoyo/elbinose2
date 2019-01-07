using UnityEngine;
using System.Collections;


public class EnemyBehaviour : CharacterBase {
	public int xp;
	public AudioClip somDano;
	public AudioClip somEspada;
	public int typeEnemy;
	public float contador;
	public float maxHP;
	public float currentHP;
	public float maxMP;
	public float currentMP;
	public Transform player;
	public Vector3 diferenca;
	// Use this for initialization
	protected void Start () {
		base.Start();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		maxHP = basicStats.startHP;
		currentHP = basicStats.startHP;
		maxMP = basicStats.startHP;
		currentMP = basicStats.startHP;
		contador = 0;
	}

	// Update is called once per frame
	protected void Update () {
		diferenca = transform.position - player.position;
		base.Update();
		if (contador < 5)
						contador += Time.deltaTime;
				else
						contador = 5;
		if (currentHP <= 0) {
						PlayerStatsController.AddXp (xp);
						if (typeEnemy == 0)
						EnemySpawn.enemyspawned -= 1;
						if (typeEnemy == 1)
						BossSpawn.bossspawned -= 1;
						Destroy (gameObject);
				}
	}
	void OnCollisionStay2D (Collision2D target) // Dano
	{
		if (target.collider.tag == "Player" && PlayerPrefs.GetFloat (PlayerStatsController.CurrentSave ()+"currentHP") > 0 && contador > 0.5f) {
			PlayerStatsController.TakeDamage(basicStats.baseAttack);
			AudioSource.PlayClipAtPoint(somDano, player.position);
			contador = 0;
		}

	}
	void OnTriggerEnter2D ( Collider2D espada) {
		if (espada.isTrigger && espada.GetComponent<Collider2D>().tag == "Sword" && currentHP > 0 && PlayerPrefs.GetInt ("inAtk") == 1) {
			int damage = (Mathf.CeilToInt(PlayerPrefs.GetFloat (PlayerStatsController.CurrentSave () + "ATK")) - basicStats.baseDefense);
			if (damage < 1)
				damage = 1;
			print ( damage );
						currentHP = currentHP - damage;
						AudioSource.PlayClipAtPoint (somEspada, transform.position);
							if (diferenca.y > 0.1) {
								GetComponent<Rigidbody2D>().AddForce(new Vector3(0,10,0) * Time.deltaTime );
							} else
							if (diferenca.y < -0.1) {
								GetComponent<Rigidbody2D>().AddForce(new Vector3(0,-10,0) * Time.deltaTime );
							}
							if (diferenca.x < -0.1) {
								GetComponent<Rigidbody2D>().AddForce(new Vector3(-10,0,0) * Time.deltaTime );
							} else
							if (diferenca.x > 0.1) {
								GetComponent<Rigidbody2D>().AddForce(new Vector3(10,0,0) * Time.deltaTime );
							}
			PlayerPrefs.SetInt ("inAtk" , 0);
				}
		}
}