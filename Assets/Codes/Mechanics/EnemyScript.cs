using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	
	public GameObject enemyPrefab;
	public int minEnemy;
	public int maxEnemy;
	private int numberOfEnemy;
	private GameObject enemyClan;

	void Start(){
		Invoke("SpawnEnemy", 3f);
	}

	void SpawnEnemy () {

		enemyClan = new GameObject("Enemy Clan");

		numberOfEnemy = Random.Range(minEnemy, maxEnemy);

		for (int i = 0; i < numberOfEnemy; i++) {
			Vector2 position = new Vector2(Random.Range(0F, 100F), Random.Range(0F, 100F));
			GameObject Enemy = (GameObject) Instantiate (enemyPrefab, position, Quaternion.identity);
			Enemy.name = "Enemy";
			Enemy.transform.parent = enemyClan.transform;
		}
	}


}