using UnityEngine;
using System.Collections;

public class BossSpawn : MonoBehaviour {
	
		public float delayspawn;
		private float spawncontboss;
		public static int bossspawned;
		public GameObject enemy;
		public static int limitBoss;
		// Use this for initialization
		void Start () {
			bossspawned = 0;
			spawncontboss = 0;
		}
		
		// Update is called once per frame
		void Update () {
			if ( spawncontboss < 100)
				spawncontboss += Time.deltaTime;
			if (bossspawned == limitBoss)
				spawncontboss = 0;
			if (bossspawned < limitBoss && spawncontboss >delayspawn) {
				Instantiate (enemy, transform.position, transform.rotation);
				enemy.GetComponent<Rigidbody2D>().AddForce(new Vector3(0,1,0) * Time.deltaTime * 0.5f);
				bossspawned ++;
				spawncontboss = 0;
			}
		}
	}
