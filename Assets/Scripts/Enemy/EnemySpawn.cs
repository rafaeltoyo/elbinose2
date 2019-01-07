using UnityEngine;
using System.Collections;

public class EnemySpawn: MonoBehaviour {
	public float delayspawn;
	private float spawncont;
	public static int enemyspawned;
	public GameObject enemy;
	public static int limitEnemy;
	// Use this for initialization
	void Start () {
		enemyspawned = 0;
		spawncont = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if ( spawncont < 100)
		spawncont += Time.deltaTime;
		if (enemyspawned == limitEnemy)
						spawncont = 0;
		if (enemyspawned < limitEnemy && spawncont >delayspawn) {
						Instantiate (enemy, transform.position, transform.rotation);
						enemyspawned ++;
						spawncont = 0;
				}
	}
}
