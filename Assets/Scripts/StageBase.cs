using UnityEngine;
using System.Collections;

public class StageBase : MonoBehaviour {

		public int maxEnemy;
		public int maxBoss;
	// Use this for initialization
	void Start () {
		EnemySpawn.limitEnemy = maxEnemy;
		BossSpawn.limitBoss = maxBoss;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
